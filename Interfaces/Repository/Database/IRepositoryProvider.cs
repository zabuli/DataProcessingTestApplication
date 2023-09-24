using Microsoft.EntityFrameworkCore;

namespace Interfaces.Repository.Database
{
	public interface IRepositoryProvider
	{
        DbContext? DbContext { get; set; }

        IGenericRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepository<T>(Func<DbContext, object>? factory = null) where T : class;

        void SetRepository<T>(T repository);
    }
}