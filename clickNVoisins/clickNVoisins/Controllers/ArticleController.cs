using clickNVoisins.Data;
using clickNVoisins.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clickNVoisins.Controllers
{
	public class ArticleController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private IWebHostEnvironment _hostingEnvironment;

		public ArticleController(ApplicationDbContext injectedContext,
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
            return View(_context.Articles.Where(a => a.User == user));
        }

        [HttpGet("/Ad/Edit/{id?}")]
        public IActionResult GetEdit(int id)
        {
            Article article = _context.Articles.SingleOrDefault(a => a.ArticleId == id);
            if (article == null)
            {
                article = new Article();
            }
            return View("Edit", article);
        }

        [HttpPost("/Ad/Edit")]
        public async Task<IActionResult> PostEdit(Article givenArticle)
        {
            User user = await _userManager.GetUserAsync(this.User);
            Article existingArticle = _context.Articles.SingleOrDefault(ad => ad.ArticleId == givenArticle.ArticleId);
            if (existingArticle != null)
            {
                if (existingArticle.User.Id == user.Id)
                {
                    _context.Untrack(existingArticle);
                    _context.Update(givenArticle);
                }
                else
                {
                    return Unauthorized("Ad update forbidden: you do not own the ad");
                }
            }
            else
            {
                givenArticle.User = user;
                _context.Add(givenArticle);
            }
            _context.SaveChanges();
            IEnumerable<Article> userArticles = _context.FindArticlesByUser(user);
            return View("List", userArticles);
        }

        [HttpGet("/Ad/Delete/{givenAdId}")]
        public async Task<IActionResult> Delete(Int32 givenArticleId)
        {
            User user = await _userManager.GetUserAsync(this.User);
            Article existingArticle = _context.Articles.SingleOrDefault(article => article.ArticleId == givenArticleId);
            if (existingArticle != null && existingArticle.User.Id == user.Id)
            {
                _context.Remove(existingArticle);
                _context.SaveChanges();
            }
            IEnumerable<Article> userArticles = _context.FindArticlesByUser(user);
            return View("List", userArticles);
        }
    }
}
