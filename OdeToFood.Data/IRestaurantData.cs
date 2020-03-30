using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "George's Pizza", Location = "Korydallos", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Vera Napoli", Location = "Glyfada", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 3, Name = "New Delhi", Location = "Athens", Cuisine = CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;


        }
    }
}
