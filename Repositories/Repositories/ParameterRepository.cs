using Application.Contract.Dtos;
using Interfaces.Repository.Repositories;
using Repositories;
using Repositories.Database;

namespace Repository.Repositories
{
	public class ParameterRepository : GenericRepository<ParameterDto>, IParameterRepository
    {
		public ParameterRepository(MyDbContext dbContext) : base(dbContext)
        {
		}
	}
}