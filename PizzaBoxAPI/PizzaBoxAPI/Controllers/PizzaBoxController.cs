using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PizzaBoxAPI.Controllers
{
    public class PizzaBoxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
