using MovieAPI.Domain.Entities;
namespace MovieAPI.Infrastructure.IRepository
{
	public interface IMovieRepository : IBaseRepository<Movie>
	{
		void Update(Movie movie);
	}
}