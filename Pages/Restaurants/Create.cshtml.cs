using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Misan_Diana_ProiectRestaurant.Data;
using Misan_Diana_ProiectRestaurant.Models;

namespace Misan_Diana_ProiectRestaurant.Pages.Restaurants
{
    public class CreateModel : RestaurantCategoriesPageModel

    {
        private readonly Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext _context;

        public CreateModel(Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PayMethodID"] = new SelectList(_context.Set<PayMethod>(), "ID", "PayMethodName");
            var restaurant = new Restaurant();
            restaurant.RestaurantCategories = new List<RestaurantCategory>();
            PopulateAssignedCategoryData(_context, restaurant);

            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newRestaurant = new Restaurant();
            if (selectedCategories != null)
            {
                newRestaurant.RestaurantCategories = new List<RestaurantCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new RestaurantCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newRestaurant.RestaurantCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Restaurant>(
            newRestaurant,
            "Restaurant",
            i => i.Order, i => i.RestaurantName,
            i => i.Price, i => i.OpeningDate, i => i.PayMethodID))
            {
                _context.Restaurant.Add(newRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newRestaurant);
            return Page();
        }

    }
}
