using Application.Contract.Dtos;
using AutoMapper;
using Domain.Models;
using File;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
    public class SymbolService : BaseService, ISymbolService
    {
        public SymbolService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        public bool ImportSymbolData(Stream fileStream)
        {
            try
            {
                const int SYMBOL_COLUMN_COUNT = 15;
                var symbols = CsvParser.GetlData<Symbol>(fileStream, SYMBOL_COLUMN_COUNT, out bool isFileValid);
                if (!isFileValid)
                {
                    return false;
                }

                var symbolsDto = _mapper.Map<List<SymbolDto>>(symbols);
                _unitOfWork.Symbol.Insert(symbolsDto);

                return true;
            }
            catch(Exception ex)
            {
                //logging
                return false;
            }
        }
    }
}