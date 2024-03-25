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
        private readonly WarehouseDbContext _context;

        public SupplycategoriesController(WarehouseDbContext context)
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

            var supplycategory = await _context.Supplycategories
                .FirstOrDefaultAsync(m => m.SupplycategoryId == id);
            if (supplycategory == null)
            {
                return NotFound();
            }

            return View(supplycategory);
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
        public async Task<IActionResult> Create([Bind("SupplycategoryId,Name,UserId")] Supplycategory supplycategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplycategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplycategory);
        }

        // GET: Supplycategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplycategory = await _context.Supplycategories.FindAsync(id);
            if (supplycategory == null)
            {
                return NotFound();
            }
            return View(supplycategory);
        }

        // POST: Supplycategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplycategoryId,Name,UserId")] Supplycategory supplycategory)
        {
            if (id != supplycategory.SupplycategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplycategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplycategoryExists(supplycategory.SupplycategoryId))
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
            return View(supplycategory);
        }

        // GET: Supplycategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplycategory = await _context.Supplycategories
                .FirstOrDefaultAsync(m => m.SupplycategoryId == id);
            if (supplycategory == null)
            {
                return NotFound();
            }

            return View(supplycategory);
        }

        // POST: Supplycategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplycategory = await _context.Supplycategories.FindAsync(id);
            if (supplycategory != null)
            {
                _context.Supplycategories.Remove(supplycategory);
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
