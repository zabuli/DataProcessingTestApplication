namespace Interfaces.Application.Services
{
	public interface IIndicatorService
	{
        bool ImportIndicators(Stream fileStream);
    }
}