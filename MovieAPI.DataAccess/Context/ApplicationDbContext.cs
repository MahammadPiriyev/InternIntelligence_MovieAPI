using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DataAccess.Configurations;
using MovieAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.DataAccess.Context
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Category> Categories { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new MovieConfiguration());
			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.HasNoKey();
			});
			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.HasNoKey();
			});
			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.HasNoKey();
			});
		}
	}
}
