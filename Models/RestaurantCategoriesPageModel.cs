using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Misan_Diana_ProiectRestaurant.Data;

namespace Misan_Diana_ProiectRestaurant.Models
{
    public class RestaurantCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Misan_Diana_ProiectRestaurantContext context,
        Restaurant restaurant)
        {
            var allCategories = context.Category;
            var restaurantCategories = new HashSet<int>(
            restaurant.RestaurantCategories.Select(c => c.RestaurantID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = restaurantCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateRestaurantCategories(Misan_Diana_ProiectRestaurantContext context,
 string[] selectedCategories, Restaurant restaurantToUpdate)
        {
            if (selectedCategories == null)
            {
                restaurantToUpdate.RestaurantCategories = new List<RestaurantCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var restaurantCategories = new HashSet<int>
            (restaurantToUpdate.RestaurantCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!restaurantCategories.Contains(cat.ID))
                    {
                        restaurantToUpdate.RestaurantCategories.Add(
                        new RestaurantCategory
                        {
                            RestaurantID = restaurantToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (restaurantCategories.Contains(cat.ID))
                    {
                        RestaurantCategory courseToRemove
                        = restaurantToUpdate
                        .RestaurantCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
        }
}
