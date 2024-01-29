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
    public class InventorycodesController : Controller
    {
        private readonly WarehouseDbContext _context;

        public InventorycodesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Inventorycodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inventorycodes.ToListAsync());
        }

        // GET: Inventorycodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventorycode = await _context.Inventorycodes
                .FirstOrDefaultAsync(m => m.Name == id);
            if (inventorycode == null)
            {
                return NotFound();
            }

            return View(inventorycode);
        }

        // GET: Inventorycodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventorycodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Inventorycode inventorycode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventorycode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventorycode);
        }

        // GET: Inventorycodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventorycode = await _context.Inventorycodes.FindAsync(id);
            if (inventorycode == null)
            {
                return NotFound();
            }
            return View(inventorycode);
        }

        // POST: Inventorycodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description")] Inventorycode inventorycode)
        {
            if (id != inventorycode.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventorycode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventorycodeExists(inventorycode.Name))
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
            return View(inventorycode);
        }

        // GET: Inventorycodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventorycode = await _context.Inventorycodes
                .FirstOrDefaultAsync(m => m.Name == id);
            if (inventorycode == null)
            {
                return NotFound();
            }

            return View(inventorycode);
        }

        // POST: Inventorycodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var inventorycode = await _context.Inventorycodes.FindAsync(id);
            if (inventorycode != null)
            {
                _context.Inventorycodes.Remove(inventorycode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventorycodeExists(string id)
        {
            return _context.Inventorycodes.Any(e => e.Name == id);
        }
    }
}
