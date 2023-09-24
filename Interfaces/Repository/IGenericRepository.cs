namespace Interfaces.Repository
{
	public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
    }
}