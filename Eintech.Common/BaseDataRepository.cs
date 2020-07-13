using Ardalis.GuardClauses;
using Eintech.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Common
{
    public abstract class BaseDataRepository<T> : IDataRepository<T> where T : class, IDataModel
    {
		protected BaseDataRepository(DbContext dataContext)
        {
            this.DataContext = dataContext;
            DbSet = DataContext.Set<T>();
        }

		protected DbContext DataContext { get; }
		public DbSet<T> DbSet { get; }

		public virtual async Task<T> Add(T entity)
        {
            try
            {
                Guard.Against.Null(entity, nameof(entity));
                var added = DbSet.Add(entity);
                _ = await DataContext.SaveChangesAsync().ConfigureAwait(false);
                return added.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

		public virtual async Task<T> GetById(long id)
		{
			T result = await DbSet.Where(s => s.Id == id).FirstOrDefaultAsync();

			return result;
		}
    }
}
