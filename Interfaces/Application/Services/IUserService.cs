using Domain.Models;

namespace Interfaces.Application.Services
{
	public interface IUserService
	{
        Task<User> GetUser(int id);
        User? GetUser(string name, string password);
    }
}