using Ardalis.GuardClauses;
using Eintech.BusinessLayer.Interfaces;
using Eintech.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Controllers
{
	[Route("api/person")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonDataService personDataService;

		public PersonController(IPersonDataService personDataService)
		{
			this.personDataService = personDataService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<Person[]> GetAll()
		{
			IQueryable<Person> persons = personDataService.GetAll();

			return Ok(persons);
		}

		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Person>> Get(int id)
		{
			Person person = await personDataService.GetById(id);
			if (person == null)
			{
				return new NotFoundResult();
			}

			return Ok(person);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Create([FromBody] Person person)
		{
			Guard.Against.NullOrWhiteSpace(person.FirstName, "firstName");
			Guard.Against.NullOrWhiteSpace(person.LastName, "lastName");

			var addedPerson = await personDataService.Add(person);
			return CreatedAtAction(nameof(Get), new { id = addedPerson.Id }, addedPerson);
		}
	}
}
