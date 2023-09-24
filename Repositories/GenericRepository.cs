using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Repositories.Database;

namespace Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(DbContext dbContext)
        {
            DbContext = (MyDbContext)dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = DbContext.Set<T>();

            DbContext.Database.SetCommandTimeout(150000);
        }

        protected MyDbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public async Task<T?> GetById(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbSet.Add(entity);
            DbContext.SaveChanges();
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                DbSet.Add(entity);
            }

            DbContext.SaveChanges();
        }
    }
}