using AutoMapper;
using Interfaces.Repository.Database;

namespace Application.Services
{
	public class BaseService
	{
		protected readonly IMapper _mapper;
		protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }
	}
}

