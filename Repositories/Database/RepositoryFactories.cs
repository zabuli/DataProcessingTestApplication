using Interfaces.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Database;
using Repository.Repositories;

namespace Repository.Database
{
	public class RepositoryFactories
	{
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        public RepositoryFactories()
		{
            _repositoryFactories = GetRepositoryFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object>? GetRepositoryFactory<T>()
        {
            _repositoryFactories.TryGetValue(typeof(T), out var factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new GenericRepository<T>(dbContext);
        }

        private IDictionary<Type, Func<DbContext, object>> GetRepositoryFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {
                   {typeof(IIndicatorRepository), dbContext => new IndicatorRepository((MyDbContext)dbContext)},
                   {typeof(IParameterRepository), dbContext => new ParameterRepository((MyDbContext)dbContext)},
                   {typeof(ISymbolRepository), dbContext => new SymbolRepository((MyDbContext)dbContext)},
                   {typeof(IUserRepository), dbContext => new UserRepository((MyDbContext)dbContext)}
                };
        }
    }
}