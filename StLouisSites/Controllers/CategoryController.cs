using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Models;
using StLouisSites.ViewModels.Category;

namespace StLouisSites.Controllers
{
    public class CategoryController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public CategoryController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            List<CategoryListItemViewModel> categories = CategoryListItemViewModel.GetCategories(repositoryFactory);
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repositoryFactory.GetCategoryRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}