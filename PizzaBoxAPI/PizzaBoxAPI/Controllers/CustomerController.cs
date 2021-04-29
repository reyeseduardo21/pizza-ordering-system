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
    public class CustomerController : ControllerBase
    {
        private readonly IRepository repo;
        public CustomerController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MCustomer> Get()
        {
            try
            {
                return Ok(repo.GetCustomers());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]//https://localhost:5001/api/Customer/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MCustomer> GetById([FromRoute] int id)
        {
            try
            {
                var x = repo.GetCustomerById(id);
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
        public IActionResult Post([FromBody] MCustomer customer)
        {
            try
            {
                if (customer == null)
                    return BadRequest("Data is invalid or null");
                repo.AddCustomer(customer);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }


        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    try
        //    {
        //        if (repo.GetCustomerById(id) == null)
        //            return BadRequest("Item does not exist");
        //        repo.DeleteCustomer(id);
        //        return NoContent();
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(400, e.Message);
        //    }
        //}
    }
}
