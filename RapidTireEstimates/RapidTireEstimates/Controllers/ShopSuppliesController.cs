using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Controllers
{
    public class ShopSuppliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopSuppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShopSupplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShopSupply.ToListAsync());
        }

        // GET: ShopSupplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShopSupply == null)
            {
                return NotFound();
            }

            ShopSupply? shopSupply = await _context.ShopSupply
                .FirstOrDefaultAsync(m => m.Id == id);
            return shopSupply == null ? NotFound() : View(shopSupply);
        }

        // GET: ShopSupplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShopSupplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstimateId,Name,Description,Id,Value")] ShopSupply shopSupply)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(shopSupply);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopSupply);
        }

        // GET: ShopSupplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShopSupply == null)
            {
                return NotFound();
            }

            ShopSupply? shopSupply = await _context.ShopSupply.FindAsync(id);
            return shopSupply == null ? NotFound() : View(shopSupply);
        }

        // POST: ShopSupplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstimateId,Name,Description,Id,Value")] ShopSupply shopSupply)
        {
            if (id != shopSupply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(shopSupply);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopSupplyExists(shopSupply.Id))
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
            return View(shopSupply);
        }

        // GET: ShopSupplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShopSupply == null)
            {
                return NotFound();
            }

            ShopSupply? shopSupply = await _context.ShopSupply
                .FirstOrDefaultAsync(m => m.Id == id);
            return shopSupply == null ? NotFound() : View(shopSupply);
        }

        // POST: ShopSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShopSupply == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShopSupply'  is null.");
            }
            ShopSupply? shopSupply = await _context.ShopSupply.FindAsync(id);
            if (shopSupply != null)
            {
                _ = _context.ShopSupply.Remove(shopSupply);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopSupplyExists(int id)
        {
            return _context.ShopSupply.Any(e => e.Id == id);
        }
    }
}
