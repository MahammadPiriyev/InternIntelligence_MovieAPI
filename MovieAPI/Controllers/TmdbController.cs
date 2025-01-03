using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain.Services.Abstract;

namespace MovieAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TmdbController : ControllerBase
	{
		private readonly ITmdbService _tmdbService;

		public TmdbController(ITmdbService tmdbService)
		{
			_tmdbService = tmdbService;
		}

		[HttpGet("popular")]
		public async Task<IActionResult> GetPopularMovies()
		{
			var movies = await _tmdbService.GetPopularMoviesAsync();
			return Ok(movies);
		}

		[HttpGet("{movieId}")]
		public async Task<IActionResult> GetMovieById(int movieId)
		{
			var movie = await _tmdbService.GetMovieByIdAsync(movieId);
			return Ok(movie);
		}
	}
}
