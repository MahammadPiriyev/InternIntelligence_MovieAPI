using MovieAPI.Domain.Entities;

namespace MovieAPI.Domain.Services.Abstract
{
	public interface ITmdbService
	{
		Task<TmdbMovie> GetMovieByIdAsync(int movieId);
		Task<List<TmdbMovie>> GetPopularMoviesAsync();
	}
}