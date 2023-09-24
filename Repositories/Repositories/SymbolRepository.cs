using Application.Contract.Dtos;
using Interfaces.Repository.Repositories;
using Repositories;
using Repositories.Database;

namespace Repository.Repositories
{
	public class SymbolRepository : GenericRepository<SymbolDto>, ISymbolRepository
    {
		public SymbolRepository(MyDbContext dbContext) : base(dbContext)
        {
		}

		public IEnumerable<SymbolDto>? GetSymbols(string? name, DateTime timeFrom, DateTime timeTo)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return null;
			}

			return DbContext?.Symbol?.Where(x => name.Equals(x.Name) && x.TimeFrom >= timeFrom && x.TimeTo <= timeTo);
		}
	}
}