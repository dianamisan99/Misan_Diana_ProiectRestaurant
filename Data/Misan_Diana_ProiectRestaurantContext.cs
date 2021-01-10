using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Misan_Diana_ProiectRestaurant.Models;

namespace Misan_Diana_ProiectRestaurant.Data
{
    public class Misan_Diana_ProiectRestaurantContext : DbContext
    {
        public Misan_Diana_ProiectRestaurantContext (DbContextOptions<Misan_Diana_ProiectRestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Misan_Diana_ProiectRestaurant.Models.Restaurant> Restaurant { get; set; }

        public DbSet<Misan_Diana_ProiectRestaurant.Models.PayMethod> PayMethod { get; set; }

        public DbSet<Misan_Diana_ProiectRestaurant.Models.Category> Category { get; set; }
    }
}
