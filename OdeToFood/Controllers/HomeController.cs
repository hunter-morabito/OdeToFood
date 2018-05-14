using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    // Will handle requests from the root of the application
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                              IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            // If you leave View with no parameters then it will assume the name of the action (Index.cshtml)
            return View(model);
        }

        // Details will look in the URL request for a mapped ID
        public IActionResult Details(int id)
        {
            // Model is now a Restaurant obj
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                // Redirects the request to the index Action using nameof
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        
        // Add route constraints to remove ambiguity
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {
            var newRestaurant = new Restaurant();
            newRestaurant.Name = model.Name;
            newRestaurant.Cuisine = model.Cuisine;

            newRestaurant = _restaurantData.Add(newRestaurant);
            return View("Details", newRestaurant);
        }
    }
}
