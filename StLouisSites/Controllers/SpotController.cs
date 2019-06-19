﻿using System;
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
            //SpotCreateViewModel model = new SpotCreateViewModel(repositoryFactory);
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpotCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}