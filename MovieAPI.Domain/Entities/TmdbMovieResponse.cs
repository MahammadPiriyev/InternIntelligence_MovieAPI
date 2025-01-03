using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Entities
{
	public class TmdbMovieResponse
	{
		public List<TmdbMovie> Results { get; set; }
	}
}
