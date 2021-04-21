using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaService.Models;

namespace PizzaService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzaBoxController : ControllerBase
	{
		List<PizzaBox> pizza = new List<PizzaBox>()
		{
			new PizzaBox(){id = 1, realName = "Bruce Wayne", alias = "Batman", hideOut = "BatCave" },
			new PizzaBox(){id = 2, realName = "Peter Parker", alias = "Batman", hideOut = "Apartment" },
			new PizzaBox(){id = 3, realName = "Thor", alias = "Thor", hideOut = "Asgard" }
		};

		[HttpGet]
		public ActionResult<PizzaBox> Get()
		{
			return Ok(pizza);
		}

		[HttpGet("{id}")]
		public ActionResult<PizzaBox> GetById(int id)
		{
			var Box = pizza.Find(x => x.id == id);
			if (Box == null)
			{
				return NotFound($"The pizza with id {id} is not in the database");
			}

			return Ok(Box);
		}

		[HttpGet]
		public IEnumerable<PizzaBox> Get()
		{
			return pizza;
		}

		[HttpPost("{id}")]
		public IActionResult Post(PizzaBox pizzas)
		{
			if (pizzas != null)
			{
				pizza.Add(pizzas);
				return NoContent();
			}
			else
				return BadRequest("Maybe check your pizza data, either it is null or invalid");
		}

		public IActionResult Put(PizzaBox pizzas)
		{
			var PizzaFind = pizza.Find(x => x.id == pizzas.id);
			if (pizzas != null)
			{
				pizza.Add(pizzas);
				return NoContent();
			}
			else
				return BadRequest("Maybe check your pizza data, either it is null or invalid");
		}

	}
}
