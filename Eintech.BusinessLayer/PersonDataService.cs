using Eintech.BusinessLayer.Interfaces;
using Eintech.Common;
using Eintech.DataLayer.Interfaces;
using Eintech.DataModels;

namespace Eintech.BusinessLayer
{
	public class PersonDataService: BaseDataService<Person>, IPersonDataService
    {

        public PersonDataService(IPersonRepository repository): base(repository)
        {
            this.repository = repository;
        }
    }
}
