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
    public class IngredientsController : Controller
    {
        private readonly WarehouseDbContext _context;

        public IngredientsController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Ingredients.Include(i => i.MenuItem).Include(i => i.Supply);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.MenuItem)
                .Include(i => i.Supply)
                .FirstOrDefaultAsync(m => m.IdIngredients == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems");
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIngredients,MenuItemId,SupplyId,CreatedTs,UpdatedTs")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems", ingredient.MenuItemId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies", ingredient.SupplyId);
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems", ingredient.MenuItemId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies", ingredient.SupplyId);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIngredients,MenuItemId,SupplyId,CreatedTs,UpdatedTs")] Ingredient ingredient)
        {
            if (id != ingredient.IdIngredients)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IdIngredients))
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
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems", ingredient.MenuItemId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies", ingredient.SupplyId);
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.MenuItem)
                .Include(i => i.Supply)
                .FirstOrDefaultAsync(m => m.IdIngredients == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IdIngredients == id);
        }
    }
}
