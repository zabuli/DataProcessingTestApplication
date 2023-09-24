using Application.Contract.Dtos;

namespace Interfaces.Repository.Repositories
{
	public interface ISymbolRepository : IGenericRepository<SymbolDto>
    {
        IEnumerable<SymbolDto>? GetSymbols(string? name, DateTime timeFrom, DateTime timeTo);
    }
}