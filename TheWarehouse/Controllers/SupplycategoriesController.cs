using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWarehouse.Data;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class SupplycategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplycategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Supplycategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supplycategories.ToListAsync());
        }

        // GET: Supplycategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Supplycategory = await _context.Supplycategories
                .FirstOrDefaultAsync(m => m.SupplycategoryId == id);
            if (Supplycategory == null)
            {
                return NotFound();
            }

            return View(Supplycategory);
        }

        // GET: Supplycategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplycategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplycategoryId,Name")] Supplycategory Supplycategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Supplycategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Supplycategory);
        }

        // GET: Supplycategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Supplycategory = await _context.Supplycategories.FindAsync(id);
            if (Supplycategory == null)
            {
                return NotFound();
            }
            return View(Supplycategory);
        }

        // POST: Supplycategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplycategoryId,Name")] Supplycategory Supplycategory)
        {
            if (id != Supplycategory.SupplycategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Supplycategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplycategoryExists(Supplycategory.SupplycategoryId))
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
            return View(Supplycategory);
        }

        // GET: Supplycategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Supplycategory = await _context.Supplycategories
                .FirstOrDefaultAsync(m => m.SupplycategoryId == id);
            if (Supplycategory == null)
            {
                return NotFound();
            }

            return View(Supplycategory);
        }

        // POST: Supplycategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Supplycategory = await _context.Supplycategories.FindAsync(id);
            if (Supplycategory != null)
            {
                _context.Supplycategories.Remove(Supplycategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplycategoryExists(int id)
        {
            return _context.Supplycategories.Any(e => e.SupplycategoryId == id);
        }
    }
}
