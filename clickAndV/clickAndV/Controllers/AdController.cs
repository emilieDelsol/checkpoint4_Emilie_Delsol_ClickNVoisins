using clickAndV.Data;
using clickAndV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace clickAndV.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private IWebHostEnvironment _hostingEnvironment;

        public AdController (ApplicationDbContext injectedContext,
                             UserManager<User> injectedUserManager,
                             IWebHostEnvironment injectedHostingEnvironment)
        {
            _context = injectedContext;
            _userManager = injectedUserManager;
            _hostingEnvironment = injectedHostingEnvironment;
        }

        public async Task<IActionResult> List()
        {
            User user = await _userManager.GetUserAsync(this.User);
            return View(_context.Ads.Where(a => a.User == user));
        }

        [HttpGet("/Ad/Edit/{id?}")]
        public IActionResult GetEdit(Guid id)
        {
            Ad ad = _context.Ads.SingleOrDefault(a => a.AdId == id);
            if (ad == null)
            {
                ad = new Ad();
            }
            return View("Edit", ad);
        }

        [HttpPost("/Ad/Edit")]
        public async Task<IActionResult> PostEdit(Ad givenAd)
        {
            User user = await _userManager.GetUserAsync(this.User);
            Ad existingAd = _context.Ads.SingleOrDefault(ad => ad.AdId == givenAd.AdId);
            if (existingAd != null)
            {
                if (existingAd.User.Id == user.Id)
                {
                    _context.Untrack(existingAd);
                    _context.Update(givenAd);
                }
                else
                {
                    return Unauthorized("Ad update forbidden: you do not own the ad");
                }
            }
            else
            {
                givenAd.User = user;
                _context.Add(givenAd);
            }
            _context.SaveChanges();
            IEnumerable<Ad> userAds = _context.FindAdsByUser(user);
            return View("List", userAds) ;
        }

        [HttpGet("/Ad/Delete/{givenAdId}")]
        public async Task<IActionResult> Delete(Guid givenAdId)
        {
            User user = await _userManager.GetUserAsync(this.User);
            Ad existingAd = _context.Ads.SingleOrDefault(ad => ad.AdId == givenAdId);
            if (existingAd != null && existingAd.User.Id == user.Id)
            {
                _context.Remove(existingAd);
                _context.SaveChanges();
            }
            IEnumerable<Ad> userAds = _context.FindAdsByUser(user);
            return View("List", userAds);
        }
    }
}
