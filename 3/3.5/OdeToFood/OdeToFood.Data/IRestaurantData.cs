using OdeToFood.Core;
using System.Collections.Generic;
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
                new Restaurant { Id = 1, Name = "Zizzi's", Location = "Nottingham", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Tamatanga", Location = "London", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Gourmet Burger Kitchen", Location = "Las Iguanas", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
