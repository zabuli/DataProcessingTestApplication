using Domain.Models;

namespace Interfaces.Application.Services
{
	public interface IUserService
	{
        User? GetUser(string name, string password);
        User? GetUser(string token);
        void UpdateToken(int userId, string token);
    }
}