using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace PizzaBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaSizeController : ControllerBase
    {
        private readonly IRepository repo;
        public PizzaSizeController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Size> Get()
        {
            try
            {
                return Ok(repo.GetSizes());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]//https://localhost:5001/api/Store/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Size> GetById([FromRoute] int id)
        {
            try
            {
                var x = repo.GetSizeByIndex(id);
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
