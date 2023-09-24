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

        public async Task<User> GetUser(int id)
        {
            var user = await _unitOfWork.User.GetById(id);
            return _mapper.Map<User>(user);
        }

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
            return _mapper.Map<User>(user);
        }
	}
}