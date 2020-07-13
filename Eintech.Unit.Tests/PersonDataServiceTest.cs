using Eintech.BusinessLayer;
using Eintech.DataLayer.Interfaces;
using Eintech.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Unit.Tests
{
	[TestClass]
	public class PersonDataServiceTest
	{
		private Mock<IPersonRepository> repository;

		[TestInitialize]
		public void Initialize()
		{
			repository = new Mock<IPersonRepository>();
		}
		
		[TestMethod]
		public void GetAll_ShouldReturnAllPersons()
		{
			// arrange
			var expected = new List<Person>
			{
			   new Person { Id = 1, FirstName = "Andrew", LastName = "McArthur" },
			   new Person { Id = 2, FirstName = "Peter", LastName = "Celver" }
			}.AsQueryable();
			repository.Setup(rep => rep.GetAll()).Returns(expected);
			PersonDataService dataService = new PersonDataService(repository.Object);

			// act
			IQueryable<Person> actual = dataService.GetAll();

			// assert
			Assert.AreEqual(expected, actual);
			Assert.AreEqual(2, actual.Count());
		}

		[TestMethod]
		public async Task Add_WhenPersonProvided_ShouldAddPerson()
		{
			// arrange
			Person person = new Person {Id= 1, FirstName = "Andrew", LastName = "Armstrong" };
			Person expected = new Person { Id = 2, FirstName = "Peter", LastName = "Celver" };
			repository.Setup(rep => rep.Add(person)).ReturnsAsync(expected);

			PersonDataService dataService = new PersonDataService(repository.Object);

			// act
			Person actual = await dataService.Add(person);

			// assert
			Assert.IsInstanceOfType(actual, typeof(Person));
			Assert.AreEqual(expected, actual);
		}
	}
}
