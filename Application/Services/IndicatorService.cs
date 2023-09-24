using AutoMapper;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
	public class IndicatorService : BaseService, IIndicatorService
    {
		public IndicatorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{ }
	}
}