using Application.Contract.Dtos;

namespace Interfaces.Repository.Repositories
{
	public interface IUserRepository : IGenericRepository<UserDto>
    {
        UserDto? GetUser(string name, string password);
        UserDto? GetUser(string token);
        void UpdateToken(int userId, string token);
    }
}