using clickNVoisins.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clickNVoisins.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Article> Articles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Departement> Departements{ get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Village> Villages { get; set; }

        public IQueryable<Article> FindArticlesByUser(User user)
        {
            return Articles.Where(a => a.User.Id == user.Id);
        }

        /// <summary>
        /// Untrack preceding entity. It is forbidden in EFCore
        /// to update a tracked entity by another one having
        /// the same identifier.
        /// ref: https://stackoverflow.com/questions/27423059/how-do-i-clear-tracked-entities-in-entity-framework
        /// </summary>
        /// <param name="trackedAd"></param>
        internal void Untrack(Article trackedAd)
        {
            Entry(trackedAd).State = EntityState.Detached;
        }
    }
}
