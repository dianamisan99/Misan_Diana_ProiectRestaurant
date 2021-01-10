using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Misan_Diana_ProiectRestaurant.Data;
using Misan_Diana_ProiectRestaurant.Models;

namespace Misan_Diana_ProiectRestaurant.Pages.PayMethods
{
    public class DetailsModel : PageModel
    {
        private readonly Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext _context;

        public DetailsModel(Misan_Diana_ProiectRestaurant.Data.Misan_Diana_ProiectRestaurantContext context)
        {
            _context = context;
        }

        public PayMethod PayMethod { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PayMethod = await _context.PayMethod.FirstOrDefaultAsync(m => m.ID == id);

            if (PayMethod == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
