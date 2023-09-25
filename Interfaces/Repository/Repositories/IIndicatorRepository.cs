using Application.Contract.Dtos;

namespace Interfaces.Repository.Repositories
{
	public interface IIndicatorRepository : IGenericRepository<IndicatorDto>
    {
        IEnumerable<IndicatorDto>? GetSymbolIndicators(DateTime timeFrom, DateTime timeTo, IEnumerable<IndicatorDto> indicators);
        IEnumerable<IndicatorDto>? GetIndicatorsByName(string? name, int? userId);
        IndicatorDto? GetIndicator(string? name, DateTime timeFrom, DateTime timeTo);
    }
}