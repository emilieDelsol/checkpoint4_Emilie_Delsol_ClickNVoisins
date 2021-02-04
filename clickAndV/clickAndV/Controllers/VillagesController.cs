using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clickAndV.Data;
using clickAndV.Models;

namespace clickAndV.Controllers
{
    public class VillagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Villages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Villages.Include(v => v.Departement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Villages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var village = await _context.Villages
                .Include(v => v.Departement)
                .FirstOrDefaultAsync(m => m.VillageId == id);
            if (village == null)
            {
                return NotFound();
            }

            return View(village);
        }

        // GET: Villages/Create
        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId");
            return View();
        }

        // POST: Villages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VillageId,VillageName,VillageDescription,CreationDate,DepartementId")] Village village)
        {
            if (ModelState.IsValid)
            {
                _context.Add(village);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", village.DepartementId);
            return View(village);
        }

        // GET: Villages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var village = await _context.Villages.FindAsync(id);
            if (village == null)
            {
                return NotFound();
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", village.DepartementId);
            return View(village);
        }

        // POST: Villages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VillageId,VillageName,VillageDescription,CreationDate,DepartementId")] Village village)
        {
            if (id != village.VillageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(village);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillageExists(village.VillageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departement, "DepartementId", "DepartementId", village.DepartementId);
            return View(village);
        }

        // GET: Villages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var village = await _context.Villages
                .Include(v => v.Departement)
                .FirstOrDefaultAsync(m => m.VillageId == id);
            if (village == null)
            {
                return NotFound();
            }

            return View(village);
        }

        // POST: Villages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var village = await _context.Villages.FindAsync(id);
            _context.Villages.Remove(village);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillageExists(int id)
        {
            return _context.Villages.Any(e => e.VillageId == id);
        }
    }
}
