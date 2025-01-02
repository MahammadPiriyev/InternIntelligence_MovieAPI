using MovieAPI.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.Infrastructure.IRepository;
using MovieAPI.Infrastructure.Repository.IRepository;

namespace MovieAPI.Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public IMovieRepository Movies { get; private set; }
		public ICategoryRepository Categories { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Movies = new MovieRepository(_context);
			Categories = new CategoryRepository(_context);
		}
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
