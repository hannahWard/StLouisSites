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
            return View();
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
            return RedirectToAction(controllerName: nameof(Spot), actionName: nameof(Index));
        }
    }
}