using Domain.Models;

namespace Interfaces.Application.Services
{
	public interface IParameterService
	{
        IEnumerable<Parameter>? StoreParameters(int userId, Indicator indicator);
        IEnumerable<Parameter>? CreateParameters(Indicator indicatorWithDefaultValues, Indicator indicator);
        IEnumerable<Parameter>? UpdateParameters(Indicator indicatorWithUserValues, Indicator indicator);
    }
}