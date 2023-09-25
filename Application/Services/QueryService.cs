using Application.Contract.Dtos;
using AutoMapper;
using Domain.Models;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
	public class QueryService : BaseService, IQueryService
    {
		public QueryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
		}

		public Query? ExecuteQuery(Query query)
        {
			if (!query.IsValid())
			{
				throw new ArgumentException("Query is not valid!");
			}

			query.Indicators = query.Indicators.Where(x => x.IsValid());
			query.Symbols = query.Symbols.Where(x => x.IsValid());
            
			var symbol = query.Symbols.First();
			var symbolsDto = _unitOfWork.Symbol.GetSymbols(symbol.Name, symbol.TimeFrom, symbol.TimeTo)?.OrderBy(x => x.TimeFrom);
            if (symbolsDto == null || !symbolsDto.Any())
			{
				throw new KeyNotFoundException("No symbol found based on given data!");
			}

            var indicatorsFromQuery = _mapper.Map<IEnumerable<IndicatorDto>>(query.Indicators);
            var indicatorsDto = _unitOfWork.Indicator.GetSymbolIndicators(symbolsDto.First().TimeFrom, symbolsDto.Last().TimeTo, indicatorsFromQuery);
			if (indicatorsDto == null || !indicatorsDto.Any())
			{
                throw new KeyNotFoundException("No indicator found based on given data!");
            }

			query.Symbols = _mapper.Map<IEnumerable<Symbol>>(symbolsDto);
			query.Indicators = _mapper.Map<IEnumerable<Indicator>>(indicatorsDto);

			return query;
		}
	}
}