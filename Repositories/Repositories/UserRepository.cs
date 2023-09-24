using Application.Contract.Dtos;
using Interfaces.Repository.Repositories;
using Repositories;
using Repositories.Database;

namespace Repository.Repositories
{
	public class UserRepository : GenericRepository<UserDto>, IUserRepository
    {
		public UserRepository(MyDbContext dbContext) : base(dbContext)
		{
		}

		public UserDto? GetUser(string name, string password)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
			{
				return null;
			}

			return DbContext?.User?.FirstOrDefault(x => name.Equals(x.Name) && password.Equals(x.Password));
		}
	}
}