using Interfaces.Repository.Database;
using Interfaces.Repository.Repositories;
using Repositories.Database;

namespace Repository.Database
{
	public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IIndicatorRepository Indicator => GetRepository<IIndicatorRepository>();
        public IParameterRepository Parameter => GetRepository<IParameterRepository>();
        public ISymbolRepository Symbol => GetRepository<ISymbolRepository>();
        public IUserRepository User => GetRepository<IUserRepository>();

        protected IRepositoryProvider RepositoryProvider { get; set; }
        private MyDbContext? DbContext { get; set; }

        public UnitOfWork(IRepositoryProvider repositoryProvider, MyDbContext dbContext)
        {
            CreateDbContext(dbContext);

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        public void Commit()
        {
            DbContext?.SaveChanges();
        }

        protected void CreateDbContext(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private T GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext?.Dispose();
            }
        }
    }
}

