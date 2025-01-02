using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.DataAccess.Context;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.IRepository;
using Newtonsoft.Json;

namespace MovieAPI.Infrastructure.Repository
{
	public class MovieRepository : BaseRepository<Movie>, IMovieRepository
	{
		private readonly ApplicationDbContext _context;
		public MovieRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Movie movie)
		{
			_context.Update(movie);
		}
	}
}
