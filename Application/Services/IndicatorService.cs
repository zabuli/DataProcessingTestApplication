using Application.Contract.Dtos;
using AutoMapper;
using Domain.Models;
using File;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
	public class IndicatorService : BaseService, IIndicatorService
    {
		public IndicatorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{ }

		public bool ImportIndicators(Stream fileStream)
		{
            try
            {
                var indicators = CsvParser.GetlData<Indicator>(fileStream, out bool isFileValid);
                if (!isFileValid || indicators?.Any() == false)
                {
                    return false;
                }

                var indicatorsDto = _mapper.Map<List<IndicatorDto>>(indicators);
                _unitOfWork.Indicator.Insert(indicatorsDto);

                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }
	}
}