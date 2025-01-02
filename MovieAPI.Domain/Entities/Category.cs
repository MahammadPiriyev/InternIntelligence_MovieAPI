using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Domain.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		[ValidateNever]
		[JsonIgnore]
		public virtual List<Movie> Movies { get; set; }
	}
}
