using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Data.Repos;
using StLouisSites.Models;
using StLouisSites.ViewModels.Spot;

namespace StLouisSites.Controllers
{
    public class SpotController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public SpotController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            List<SpotListItemViewModel> spots = SpotListItemViewModel.GetSpots(repositoryFactory);
            return View(spots);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SpotCreateViewModel model = new SpotCreateViewModel(repositoryFactory);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SpotCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new SpotEditViewModel(id, repositoryFactory));
        }

        [HttpPost]
        public IActionResult Edit(int id, SpotEditViewModel spot)
        {
            if (!ModelState.IsValid)
                return View(spot);

            spot.Update(id, repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int spotId)
        {
            List<SpotRating> spotRatings = repositoryFactory
                .GetSpotRatingRepository()
                .GetModels()
                .Where(rating => rating.SpotId == spotId)
                .ToList();

            List<Spot> spots = repositoryFactory
                .GetSpotRepository()
                .GetModels()
                .Where(s => s.Id == spotId)
                .ToList();
            foreach (var spot in spots)
            {
                ViewBag.Name = spot.Name;
                ViewBag.Description = spot.Description;
                List<string> names = new List<string>();
                foreach (var category in spot.CategorySpots)
                {
                    names.Add(category.Category.Name);
                }
                ViewBag.Categories = names;
            }

            ViewBag.Id = spotId;
            return View(spotRatings);
        }
    }
}