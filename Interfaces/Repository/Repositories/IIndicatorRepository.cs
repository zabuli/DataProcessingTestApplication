
using Application.Contract.Dtos;

namespace Interfaces.Repository.Repositories
{
	public interface IIndicatorRepository : IGenericRepository<IndicatorDto>
    {
        IEnumerable<IndicatorDto>? GetSymbolIndicators(DateTime timeFrom, DateTime timeTo, IEnumerable<IndicatorDto> indicators);
    }
}

