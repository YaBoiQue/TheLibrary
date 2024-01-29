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
    public class SupplytypesController : Controller
    {
        private readonly WarehouseDbContext _context;

        public SupplytypesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Supplytypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supplytypes.ToListAsync());
        }

        // GET: Supplytypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplytype = await _context.Supplytypes
                .FirstOrDefaultAsync(m => m.Name == id);
            if (supplytype == null)
            {
                return NotFound();
            }

            return View(supplytype);
        }

        // GET: Supplytypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplytypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Supplytype supplytype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplytype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplytype);
        }

        // GET: Supplytypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplytype = await _context.Supplytypes.FindAsync(id);
            if (supplytype == null)
            {
                return NotFound();
            }
            return View(supplytype);
        }

        // POST: Supplytypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] Supplytype supplytype)
        {
            if (id != supplytype.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplytype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplytypeExists(supplytype.Name))
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
            return View(supplytype);
        }

        // GET: Supplytypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplytype = await _context.Supplytypes
                .FirstOrDefaultAsync(m => m.Name == id);
            if (supplytype == null)
            {
                return NotFound();
            }

            return View(supplytype);
        }

        // POST: Supplytypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var supplytype = await _context.Supplytypes.FindAsync(id);
            if (supplytype != null)
            {
                _context.Supplytypes.Remove(supplytype);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplytypeExists(string id)
        {
            return _context.Supplytypes.Any(e => e.Name == id);
        }
    }
}
