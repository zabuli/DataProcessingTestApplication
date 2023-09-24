namespace Interfaces.Application.Services
{
	public interface ISymbolService
	{
        bool ImportSymbolData(Stream fileStream);
    }
}