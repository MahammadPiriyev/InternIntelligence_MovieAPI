using MovieAPI.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.IRepository
{
	public interface IUnitOfWork
	{
		IMovieRepository Movies { get; }
		ICategoryRepository Categories { get; }
		void Save();
	}
}
