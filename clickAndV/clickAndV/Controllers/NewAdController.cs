using clickAndV.Data;
using clickAndV.Models;
using clickAndV.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace clickAndV.Controllers
{
    [Authorize]
	public class NewAdController :Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<User> _userManager;
        public NewAdController(ApplicationDbContext context, UserManager<User> injectedUserManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _userManager = injectedUserManager;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ads.Include(a => a.Category);
            return View(await applicationDbContext.ToListAsync());
        }

		public IActionResult New(int IdVillage)
		{
			ViewData["CategoryId"] = new SelectList(_context.Categories.Where(c => c.VillageId == IdVillage), "CategoryId", "CategoryName");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> New(AdViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = UploadedFile(model);
				string userId = _userManager.GetUserId(this.User);
				Ad ad = new Ad
				{
					AdId = Guid.NewGuid(),
					Title = model.Title,
					Text = model.Text,
					CreationDate = model.CreationDate,
					BeginDate = model.BeginDate,
					EndDate = model.EndDate,
					Banner = uniqueFileName,
					CategoryId = model.CategoryId,
					UserId =userId
				};
				_context.Add(ad);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View();
		}

		private string UploadedFile(AdViewModel model)
        {
            string uniqueFileName = null;

            if (model.Banner != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Banner.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Banner.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

