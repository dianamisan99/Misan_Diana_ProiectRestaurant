using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Misan_Diana_ProiectRestaurant.Data;
using Misan_Diana_ProiectRestaurant.Models;

namespace Misan_Diana_ProiectRestaurant.Pages.Restaurants
{
    public class IndexModel : PageModel
    {
        private readonly Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext _context;

        public IndexModel(Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }
        public RestaurantData RestaurantD { get; set; }
        public int RestaurantID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            RestaurantD = new RestaurantData();

            RestaurantD.Restaurants = await _context.Restaurant
            .Include(b => b.PayMethod)
            .Include(b => b.RestaurantCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.RestaurantName)
            .ToListAsync();
            if (id != null)
            {
                RestaurantID = id.Value;
                Restaurant restaurant = RestaurantD.Restaurants
                .Where(i => i.ID == id.Value).Single();
                RestaurantD.Categories = restaurant.RestaurantCategories.Select(s => s.Category);
            }
        }


    }
}
