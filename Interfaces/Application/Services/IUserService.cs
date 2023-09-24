using Domain.Models;

namespace Interfaces.Application.Services
{
	public interface IUserService
	{
        User? GetUser(string name, string password);
        void UpdateToken(int userId, string token);
    }
}