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
    public class PizzaBoxController : ControllerBase
    {
        private readonly IRepository repo;

        public PizzaBoxController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MOrder> Get()
        {
            try
            {
                return Ok(repo.GetAllPizzas());
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        
            
        
    }
}
