using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.IRepository;

namespace MovieAPI.Infrastructure.Repository.IRepository
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		void Update(Category category);
	}
}