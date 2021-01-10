using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misan_Diana_ProiectRestaurant.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
