using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Database;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

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

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> Insert(IEnumerable<T> entities)
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
            return entities;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbContext.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                DbContext.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;
            }

            DbContext.SaveChanges();
            return entities;
        }
    }
}