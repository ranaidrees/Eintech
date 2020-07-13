using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Common.Interfaces
{
	public interface IDataService<T> where T : class, IDataModel
	{
		Task<T> Add(T model);
		Task<T> GetById(int id);
		IQueryable<T> GetAll();
	}
}
