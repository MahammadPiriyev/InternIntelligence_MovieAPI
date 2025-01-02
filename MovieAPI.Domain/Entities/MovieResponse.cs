using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Entities
{
	public class MovieResponse
	{
		public IEnumerable<Movie> Results { get; set; }
	}
}
