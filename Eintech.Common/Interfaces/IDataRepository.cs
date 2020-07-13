using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Common.Interfaces
{
	public interface IDataRepository<T> where T : class, IDataModel
	{
		DbSet<T> DbSet { get; }
		Task<T> GetById(long id);
		IQueryable<T> GetAll();
		Task<T> Add(T entity);
	}
}
