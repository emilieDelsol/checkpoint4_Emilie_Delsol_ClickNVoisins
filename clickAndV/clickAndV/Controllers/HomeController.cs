using clickAndV.Models;
using clickAndV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace clickAndV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data.ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
                              Data.ApplicationDbContext injectedDbContext)
        {
            _logger = logger;
            _context = injectedDbContext;
        }

        public IActionResult Index()
        {
            return View(_context.Ads);
        }
        public IActionResult Dashboard()
        {
            return View(_context.Departement);
        }
        public IActionResult AccueilVillage(int VillageId)
        {
            Village village = _context.Villages.Where(v => v.VillageId == VillageId).First();
            return View(village);
        }
        public IActionResult Categories(int IdCategory)
        {
            Category category = _context.Categories.Where(c => c.CategoryId == IdCategory).First();

            return View(category);
        }
    
    }
}
