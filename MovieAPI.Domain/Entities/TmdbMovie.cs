using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Entities
{
	public class TmdbMovie
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Original_language { get; set; }
		public DateTime Release_date { get; set; }
	}
}
