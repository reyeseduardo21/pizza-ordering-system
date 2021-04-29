using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain;
using System.Net.Mime;
using PizzaBox.Data;

namespace PizzaBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrustController : ControllerBase
    {
        private readonly IRepository repo;
        public CrustController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MCrust> Get()
        {
            try
            {
                return Ok(repo.GetPizzaCrusts());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]//https://localhost:5001/api/Crust/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MCrust> GetById([FromRoute] int id)
        {
            try
            {
                var x = repo.GetCrustByIndex(id);
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

        
        
    }
}
