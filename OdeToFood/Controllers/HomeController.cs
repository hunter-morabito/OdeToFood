using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    // Will handle requests from the root of the application
    public class HomeController
    {

        public string Index()
        {
            return "Hello from the HomeController";
        }
    }
}
