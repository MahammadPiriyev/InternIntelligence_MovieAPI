using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Entities
{
	public class Movie
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public string? Author { get; set; }
		public int CategoryId { get; set; }
		[JsonIgnore]
		public virtual Category Category { get; set; }

		[Range(1, 5)]
		public int Rating { get; set; }
		public DateTime? CreatedDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; } = DateTime.Now;
	}
}
