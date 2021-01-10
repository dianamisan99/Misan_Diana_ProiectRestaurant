using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misan_Diana_ProiectRestaurant.Models
{
    public class PayMethod
    {
        public int ID { get; set; }
        public string PayMethodName { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
