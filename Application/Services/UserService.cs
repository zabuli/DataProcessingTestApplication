using AutoMapper;
using Domain.Models;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
	public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        public User? GetUser(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(password);
            }

            var user = _unitOfWork.User.GetUser(name, password);
            return user == null ? null : _mapper.Map<User>(user);
        }

        public User? GetUser(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(token);
            }

            var user = _unitOfWork.User.GetUser(token);
            return user == null ? null : _mapper.Map<User>(user);
        }

        public void UpdateToken(int userId, string token)
        {
            _unitOfWork.User.UpdateToken(userId, token);
        }
	}
}