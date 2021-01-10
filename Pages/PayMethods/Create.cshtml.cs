using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Misan_Diana_ProiectRestaurant.Data;
using Misan_Diana_ProiectRestaurant.Models;

namespace Misan_Diana_ProiectRestaurant.Pages.PayMethods
{
    public class CreateModel : PageModel
    {
        private readonly Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext _context;

        public CreateModel(Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PayMethod PayMethod { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PayMethod.Add(PayMethod);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
