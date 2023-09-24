using Domain.Models;

namespace Interfaces.Application.Services
{
	public interface IQueryService
	{
        Query? ExecuteQuery(Query query);
    }
}