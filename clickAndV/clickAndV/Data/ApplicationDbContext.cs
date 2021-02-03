using CorrectionCheckpoint3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorrectionCheckpoint3.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }

        public IQueryable<Ad> FindAdsByUser(User user)
        {
            return Ads.Where(a => a.User.Id == user.Id);
        }

        /// <summary>
        /// Untrack preceding entity. It is forbidden in EFCore
        /// to update a tracked entity by another one having
        /// the same identifier.
        /// ref: https://stackoverflow.com/questions/27423059/how-do-i-clear-tracked-entities-in-entity-framework
        /// </summary>
        /// <param name="trackedAd"></param>
        internal void Untrack(Ad trackedAd)
        {
            Entry(trackedAd).State = EntityState.Detached;
        }
    }
}
