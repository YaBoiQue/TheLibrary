using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Controllers
{
    public class PurchasedPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasedPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchasedParts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchasedPart.Include(p => p.Estimate).Include(p => p.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchasedParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurchasedPart == null)
            {
                return NotFound();
            }

            var purchasedPart = await _context.PurchasedPart
                .Include(p => p.Estimate)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchasedPart == null)
            {
                return NotFound();
            }

            return View(purchasedPart);
        }

        // GET: PurchasedParts/Create
        public IActionResult Create()
        {
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id");
            ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Make");
            return View();
        }

        // POST: PurchasedParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstimateId,VehicleId,UpsalePercent,Name,Description,Id,Value")] PurchasedPart purchasedPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchasedPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", purchasedPart.EstimateId);
            ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Make", purchasedPart.VehicleId);
            return View(purchasedPart);
        }

        // GET: PurchasedParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurchasedPart == null)
            {
                return NotFound();
            }

            var purchasedPart = await _context.PurchasedPart.FindAsync(id);
            if (purchasedPart == null)
            {
                return NotFound();
            }
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", purchasedPart.EstimateId);
            ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Make", purchasedPart.VehicleId);
            return View(purchasedPart);
        }

        // POST: PurchasedParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstimateId,VehicleId,UpsalePercent,Name,Description,Id,Value")] PurchasedPart purchasedPart)
        {
            if (id != purchasedPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchasedPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchasedPartExists(purchasedPart.Id))
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
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", purchasedPart.EstimateId);
            ViewData["VehicleId"] = new SelectList(_context.Set<Vehicle>(), "Id", "Make", purchasedPart.VehicleId);
            return View(purchasedPart);
        }

        // GET: PurchasedParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurchasedPart == null)
            {
                return NotFound();
            }

            var purchasedPart = await _context.PurchasedPart
                .Include(p => p.Estimate)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchasedPart == null)
            {
                return NotFound();
            }

            return View(purchasedPart);
        }

        // POST: PurchasedParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurchasedPart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PurchasedPart'  is null.");
            }
            var purchasedPart = await _context.PurchasedPart.FindAsync(id);
            if (purchasedPart != null)
            {
                _context.PurchasedPart.Remove(purchasedPart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchasedPartExists(int id)
        {
          return _context.PurchasedPart.Any(e => e.Id == id);
        }
    }
}
