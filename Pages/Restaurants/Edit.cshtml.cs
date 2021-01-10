using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Misan_Diana_ProiectRestaurant.Data;
using Misan_Diana_ProiectRestaurant.Models;

namespace Misan_Diana_ProiectRestaurant.Pages.Restaurants
{
    public class EditModel :  RestaurantCategoriesPageModel
    {
        private readonly Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext _context;

        public EditModel(Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurant
 .Include(b => b.PayMethod)
 .Include(b => b.RestaurantCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Restaurant);

            ViewData["PayMethodID"] = new SelectList(_context.Set<PayMethod>(), "ID", "PayMethodName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var restaurantToUpdate = await _context.Restaurant
            .Include(i => i.PayMethod)
            .Include(i => i.RestaurantCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (restaurantToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Restaurant>(
            restaurantToUpdate,
            "Restaurant",
            i => i.Order, i => i.RestaurantName,
            i => i.Price, i => i.OpeningDate, i => i.PayMethod))
            {
                UpdateRestaurantCategories(_context, selectedCategories, restaurantToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateRestaurantCategories(_context, selectedCategories, restaurantToUpdate);
            PopulateAssignedCategoryData(_context, restaurantToUpdate);
            return Page();
        }
    }
}
