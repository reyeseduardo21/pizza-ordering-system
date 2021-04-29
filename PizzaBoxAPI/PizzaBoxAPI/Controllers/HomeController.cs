using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace PizzaBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository _repository;
        public PizzaController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomPizza> Get()
        {
            try
            {
                return Ok(_repository.GetAllPizzas());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]//https://localhost:5001/api/Pizza/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomPizza> GetById([FromRoute] int id)
        {
            try
            {
                var x = _repository.GetPizzaByIndex(id);
                if (x == null)
                {
                    return NotFound($"The item with id {id} was not found in the database.");
                }
                return Ok(x);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody] CustomPizza pizza)
        {
            try
            {
                if (pizza == null)
                    return BadRequest("Data is invalid or null");
                _repository.AddPizza(pizza);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Consumes(MediaTypeNames.Application.Json)]
        //public IActionResult Put([FromBody] CustomPizza x)
        //{
        //    try
        //    {
        //        if (x == null)
        //            return BadRequest("Data is invalid or null");
        //        _repository.UpdatePizza(x);
        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(400, e.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    try
        //    {
        //        if (_repository.GetPizza(id) == null)
        //            return BadRequest("Item does not exist");
        //        _repository.DeletePizza(id);
        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(400, e.Message);
        //    }
        //}
    }
}
