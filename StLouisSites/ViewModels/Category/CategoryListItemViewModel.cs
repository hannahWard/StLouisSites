using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Category
{
    public class CategoryListItemViewModel
    {
        
        public static List<CategoryListItemViewModel> GetCategories(RepositoryFactory factory)
        {
            return factory.GetCategoryRepository()
                .GetModels()
                .Select(c => new CategoryListItemViewModel(c))
                .ToList();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        
        
        public CategoryListItemViewModel(Models.Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
    }
}
