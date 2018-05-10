using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    // Will handle requests from the root of the application
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Hunter's Pizza Place" };

            // If you leave View with no parameters then it will assume the name of the action (Index.cshtml)
            return View(model);
        }
    }
}
