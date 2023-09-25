using Domain.Models;

namespace Interfaces.Application.Services
{
	public interface IIndicatorService
	{
        bool ImportIndicators(Stream fileStream);
        IEnumerable<Indicator>? GetIndicators(string name, int? userId);
        Indicator? StoreIndicator(Indicator? indicator);
    }
}