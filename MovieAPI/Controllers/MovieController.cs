using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Infrastructure.IRepository;
using MovieAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DataAccess.Context;
using Newtonsoft.Json;

namespace MovieAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MovieController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		public MovieController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var movieFromDb = await _unitOfWork.Movies.GetAsync(m => m.Id == id);
			if (ModelState.IsValid)
			{
				return Ok(movieFromDb);
			}
			return Unauthorized();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var movieList = await _unitOfWork.Movies.GetAllAsync();
			return Ok(movieList);
		}

		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(string filter)
		{
			var query = _context.Movies.AsQueryable();

			if (!string.IsNullOrEmpty(filter))
			{
				var filterCriteria = JsonConvert.DeserializeObject<Movie>(filter);

				if (!string.IsNullOrEmpty(filterCriteria.Title))
					query = query.Where(m => m.Title.Contains(filterCriteria.Title));

				if (!string.IsNullOrEmpty(filterCriteria.Author))
					query = query.Where(m => m.Author.Contains(filterCriteria.Author));

				if (!string.IsNullOrEmpty(filterCriteria.Description))
					query = query.Where(m => m.Description.Contains(filterCriteria.Description));

				if (filterCriteria.CategoryId != 0)
					query = query.Where(m => m.CategoryId == filterCriteria.CategoryId);
			}

			var result = await query.ToListAsync();
			if (result.Count == 0)
				return BadRequest(new { message = "Movie not found!" });
			return result;
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody] Movie movie)
		{
			_unitOfWork.Movies.Add(movie);
			_unitOfWork.Save();
			return Ok(new {message = "Movie has successfully created!"});
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> Update([FromBody] Movie movie, int id)
		{
			var movieFromDb = await _unitOfWork.Movies.GetAsync(m => m.Id == id);
			movieFromDb.Title = movie.Title;
			movieFromDb.Author = movie.Author;
			movieFromDb.Description = movie.Description;
			movieFromDb.Rating = movie.Rating;

			_unitOfWork.Movies.Update(movieFromDb);
			_unitOfWork.Save();
			return Ok(new { message = $"Movie {id} has successfully updated!", movie });
		}

		[HttpDelete("remove/{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var movieFromDb = await _unitOfWork.Movies.GetAsync(m => m.Id == id);
			_unitOfWork.Movies.Remove(movieFromDb);
			_unitOfWork.Save();
			return Ok(new { message = $"Movie {id} has successfully removed!" });

		}
	}
}
