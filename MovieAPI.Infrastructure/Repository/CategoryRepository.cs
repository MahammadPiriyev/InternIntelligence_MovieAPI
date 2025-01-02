using MovieAPI.DataAccess.Context;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Repository
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Category category)
		{
			_context.Update(category);
		}
	}
}
