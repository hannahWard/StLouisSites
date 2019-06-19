using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Models;
using StLouisSites.ViewModels.SpotRating;

namespace StLouisSites.Controllers
{
    public class SpotRatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int spotId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int spotId, SpotRatingCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist();
            return RedirectToAction(controllerName: nameof(Spot), actionName: nameof(Index));
        }
    }
}