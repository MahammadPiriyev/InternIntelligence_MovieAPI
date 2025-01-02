using Microsoft.EntityFrameworkCore;
using MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataAccess.Configurations
{
	public class MovieConfiguration : IEntityTypeConfiguration<Movie>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Movie> builder)
		{
			builder.HasKey(m => m.Id);
			builder.Property(m => m.Title)
				.IsRequired()
				.HasMaxLength(20);
			builder.Property(m => m.Description)
				.IsRequired()
				.HasMaxLength(255);
			builder.Property(m => m.Author)
				.HasMaxLength(20)
				.IsRequired();
			builder.Property(m => m.Rating)
				.IsRequired();
			builder
				.HasOne(m => m.Category)
				.WithMany(c => c.Movies)
				.HasForeignKey(m => m.CategoryId);
		}
	}
}
