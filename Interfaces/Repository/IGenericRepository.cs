namespace Interfaces.Repository
{
	public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        T Insert(T entity);
        IEnumerable<T> Insert(IEnumerable<T> entities);
        T Update(T entity);
        IEnumerable<T> Update(IEnumerable<T> entities);
    }
}