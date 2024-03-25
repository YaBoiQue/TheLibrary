using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWarehouse.Data;
using TheWarehouse.ViewModels;

namespace TheWarehouse
{
    public class MenuPriceTotalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuPriceTotalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuPriceTotals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menupricetotals.ToListAsync());
        }

        // GET: MenuPriceTotals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuPriceTotal = await _context.Menupricetotals
                .FirstOrDefaultAsync(m => m.MenuitemId == id);
            if (menuPriceTotal == null)
            {
                return NotFound();
            }

            return View(menuPriceTotal);
        }

        // GET: MenuPriceTotals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuPriceTotals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuitemId,Name,MenuPrice,MenucategoryId,Total")] MenuPriceTotal menuPriceTotal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuPriceTotal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuPriceTotal);
        }

        // GET: MenuPriceTotals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuPriceTotal = await _context.Menupricetotals.FindAsync(id);
            if (menuPriceTotal == null)
            {
                return NotFound();
            }
            return View(menuPriceTotal);
        }

        // POST: MenuPriceTotals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuitemId,Name,MenuPrice,MenucategoryId,Total")] MenuPriceTotal menuPriceTotal)
        {
            if (id != menuPriceTotal.MenuitemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuPriceTotal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuPriceTotalExists(menuPriceTotal.MenuitemId))
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
            return View(menuPriceTotal);
        }

        // GET: MenuPriceTotals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuPriceTotal = await _context.Menupricetotals
                .FirstOrDefaultAsync(m => m.MenuitemId == id);
            if (menuPriceTotal == null)
            {
                return NotFound();
            }

            return View(menuPriceTotal);
        }

        // POST: MenuPriceTotals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuPriceTotal = await _context.Menupricetotals.FindAsync(id);
            if (menuPriceTotal != null)
            {
                _context.Menupricetotals.Remove(menuPriceTotal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuPriceTotalExists(int id)
        {
            return _context.Menupricetotals.Any(e => e.MenuitemId == id);
        }
    }
}
