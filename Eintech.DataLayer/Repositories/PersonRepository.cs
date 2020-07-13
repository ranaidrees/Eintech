using Eintech.Common;
using Eintech.DataLayer.Infrastructure;
using Eintech.DataLayer.Interfaces;
using Eintech.DataModels;

namespace Eintech.DataLayer.Repositories
{
	public class PersonRepository: BaseDataRepository<Person>, IPersonRepository
    {
        public PersonRepository(EintechDbContext dataContext): base(dataContext)
        {
        }
    }
}
