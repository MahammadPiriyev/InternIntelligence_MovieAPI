using System.Linq.Expressions;

namespace MovieAPI.Infrastructure.IRepository
{
	public interface IBaseRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetAsync(Expression<Func<T, bool>> filter);
		void Add(T entity);
		void Remove(T entity);
	}
}