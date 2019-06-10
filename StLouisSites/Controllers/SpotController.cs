using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Models;
using StLouisSites.ViewModels.Spot;

namespace StLouisSites.Controllers
{
    public class SpotController : Controller
    {
        private ISpotRepository spotRepository = RepositoryFactory.GetSpotRepository();

        private ApplicationDbContext context;

        public SpotController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Spot> spots = context.Spots.ToList();
            List<SpotListItemViewModel> viewModelSpots = SpotListItemViewModel.GetSpotListItemsFromSpot(spots);
            return View(viewModelSpots);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpotCreateViewModel createSpot)
        {
            Spot spot = createSpot.Persist();
            context.Add(spot);
            context.SaveChanges();
            return RedirectToAction(nameof (Index));
        }
    }
}