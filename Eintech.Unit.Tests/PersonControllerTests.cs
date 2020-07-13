using Eintech.BusinessLayer.Interfaces;
using Eintech.Controllers;
using Eintech.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Eintech.Unit.Tests
{
	[TestClass]
	public class PersonControllerTests
	{
		private Mock<IPersonDataService> dataService;

		[TestInitialize]
		public void Initialize()
		{
			dataService = new Mock<IPersonDataService>();
		}

		[TestMethod]
		public void GetAll_ShouldReturnAllPersons()
		{
			// arrange
			var expected = new List<Person>
			{
			   new Person { Id = 1, FirstName = "Andrew", LastName = "Armstrong" },
			   new Person { Id = 2, FirstName = "Peter", LastName = "Celver" }
			}.AsQueryable();
			dataService.Setup(ds => ds.GetAll()).Returns(expected);
			PersonController controller = new PersonController(dataService.Object);

			// act
			var actionResult = controller.GetAll();
			var result = actionResult.Result as OkObjectResult;

			// assert
			Assert.IsNotNull(result);
			Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
			Assert.AreEqual(expected, result.Value);
		}
		
		[TestMethod]
		public async Task Create_ShouldAddTheProvidedPerson()
		{
			// arrange
			Person person = new Person { FirstName = "Andrew", LastName = "Armstrong" };
			dataService.Setup(ds => ds.Add(It.IsAny<Person>())).ReturnsAsync(person);
			PersonController controller = new PersonController(dataService.Object);

			// act
			var actionResult = await controller.Create(person) as CreatedAtActionResult;
			var createdPerson = actionResult.Value as Person;

			// assert
			Assert.IsNotNull(actionResult);
			Assert.AreEqual((int)HttpStatusCode.Created, actionResult.StatusCode);
			Assert.AreEqual(person, createdPerson);
		}
	}
}
