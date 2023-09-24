
using Application.Contract.Dtos;

namespace Interfaces.Repository.Repositories
{
	public interface IIndicatorRepository : IGenericRepository<IndicatorDto>
    {
        IEnumerable<IndicatorDto>? GetSymbolIndicators(SymbolDto symbol, IEnumerable<IndicatorDto> indicators);
    }
}

