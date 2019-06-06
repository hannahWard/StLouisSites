using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Data;
using StLouisSites.Models;

namespace StLouisSites.Controllers
{
    public class SpotController : Controller
    {
        private ApplicationDbContext context;

        public SpotController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Spot> spots = context.Spots.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Spot spot)
        {
            context.Add(spot);
            context.SaveChanges();
            return RedirectToAction(nameof (Index));
        }
    }
}