using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            // need to use in other methods so set private field
            _context = context;
        }

        // The Id will be set to the Identity column
        // Framework will add the id value into the restaurant
        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            // changes don't occur until you save
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // In real application return an iqueriable
            return _context.Restaurants.OrderBy(r => r.Name);
        }
    }
}
