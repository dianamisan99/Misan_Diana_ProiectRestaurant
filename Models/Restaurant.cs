using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Misan_Diana_ProiectRestaurant.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        [Required, StringLength(250, MinimumLength = 3)]
        public string Order { get; set; }
        public string RestaurantName { get; set; }
        [Range(1, 300)]

        [Column(TypeName = "decimal(4, 2)")]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }
        public int PayMethodID { get; set; }
        public PayMethod PayMethod { get; set; }
        public ICollection<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
