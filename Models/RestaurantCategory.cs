using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misan_Diana_ProiectRestaurant.Models
{
    public class RestaurantCategory
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
