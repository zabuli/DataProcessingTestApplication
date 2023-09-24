using AutoMapper;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
	public class ParameterService : BaseService, IParameterService
    {
        public ParameterService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }
    }
}