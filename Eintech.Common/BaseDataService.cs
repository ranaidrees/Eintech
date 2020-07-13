using Eintech.Common.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Common
{

	public abstract class BaseDataService<T> : IDataService<T> where T : class, IDataModel
	{
		protected IDataRepository<T> repository;

		public BaseDataService(IDataRepository<T> repository)
		{
			this.repository = repository;
		}

		public async Task<T> Add(T model)
		{
			return await repository.Add(model);
		}

		public IQueryable<T> GetAll()
		{
			return repository.GetAll();
		}

		public async Task<T> GetById(int id)
		{
			return await repository.GetById(id);
		}
	}
}
