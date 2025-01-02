using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DataAccess.Context;
using MovieAPI.Infrastructure.IRepository;

namespace MovieAPI.Infrastructure.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private DbSet<T> dbSet;
		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
			dbSet = _context.Set<T>();
		}

		public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public void Add(T entity)
		{
			dbSet.Add(entity);
		}
		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}
	}
}

