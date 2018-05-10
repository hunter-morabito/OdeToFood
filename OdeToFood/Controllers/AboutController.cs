using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    // You can add strings to the route
    [Route("company/[controller]/[action]")] // Using tokens instead, they go in [], what appears in this part of the URL, then the route should start with class name
    public class AboutController
    {
        // Routing no longer needed since the token is used in the top of the class to use method names as the routes
        //[Route("")] // come to this controller and invoke this action if left as '""'
        public string Phone()
        {
            return "1+555+5555";
        }

        // Routing no longer needed since the token is used in the top of the class to use method names as the routes
        //[Route("[action]")] // must be explicit if using Attribute Routing; if using token [action] the route will go directy to the method name
        public string Address()
        {
            return "USA";
        }
    }

}
