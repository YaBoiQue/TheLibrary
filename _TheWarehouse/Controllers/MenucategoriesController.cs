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
    public class MenucategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenucategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Menucategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menucategories.ToListAsync());
        }

        // GET: Menucategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Menucategory = await _context.Menucategories
                .FirstOrDefaultAsync(m => m.MenucategoryId == id);
            if (Menucategory == null)
            {
                return NotFound();
            }

            return View(Menucategory);
        }

        // GET: Menucategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menucategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyCategoryId,Name")] Menucategory Menucategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Menucategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Menucategory);
        }

        // GET: Menucategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Menucategory = await _context.Menucategories.FindAsync(id);
            if (Menucategory == null)
            {
                return NotFound();
            }
            return View(Menucategory);
        }

        // POST: Menucategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyCategoryId,Name")] Menucategory Menucategory)
        {
            if (id != Menucategory.MenucategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Menucategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenucategoryExists(Menucategory.MenucategoryId))
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
            return View(Menucategory);
        }

        // GET: Menucategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Menucategory = await _context.Menucategories
                .FirstOrDefaultAsync(m => m.MenucategoryId == id);
            if (Menucategory == null)
            {
                return NotFound();
            }

            return View(Menucategory);
        }

        // POST: Menucategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Menucategory = await _context.Menucategories.FindAsync(id);
            if (Menucategory != null)
            {
                _context.Menucategories.Remove(Menucategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenucategoryExists(int id)
        {
            return _context.Menucategories.Any(e => e.MenucategoryId == id);
        }
    }
}
