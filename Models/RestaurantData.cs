using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misan_Diana_ProiectRestaurant.Models
{
    public class RestaurantData
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
