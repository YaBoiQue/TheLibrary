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
    public class ServiceEstimatePricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceEstimatePricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceEstimatePrices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServiceEstimatePrice.Include(s => s.ServiceEstimate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceEstimatePrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceEstimatePrice == null)
            {
                return NotFound();
            }

            var serviceEstimatePrice = await _context.ServiceEstimatePrice
                .Include(s => s.ServiceEstimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceEstimatePrice == null)
            {
                return NotFound();
            }

            return View(serviceEstimatePrice);
        }

        // GET: ServiceEstimatePrices/Create
        public IActionResult Create()
        {
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id");
            return View();
        }

        // POST: ServiceEstimatePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceEstimateId,Comment,Id,Value")] ServiceEstimatePrice serviceEstimatePrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceEstimatePrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id", serviceEstimatePrice.ServiceEstimateId);
            return View(serviceEstimatePrice);
        }

        // GET: ServiceEstimatePrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceEstimatePrice == null)
            {
                return NotFound();
            }

            var serviceEstimatePrice = await _context.ServiceEstimatePrice.FindAsync(id);
            if (serviceEstimatePrice == null)
            {
                return NotFound();
            }
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id", serviceEstimatePrice.ServiceEstimateId);
            return View(serviceEstimatePrice);
        }

        // POST: ServiceEstimatePrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceEstimateId,Comment,Id,Value")] ServiceEstimatePrice serviceEstimatePrice)
        {
            if (id != serviceEstimatePrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceEstimatePrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceEstimatePriceExists(serviceEstimatePrice.Id))
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
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id", serviceEstimatePrice.ServiceEstimateId);
            return View(serviceEstimatePrice);
        }

        // GET: ServiceEstimatePrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceEstimatePrice == null)
            {
                return NotFound();
            }

            var serviceEstimatePrice = await _context.ServiceEstimatePrice
                .Include(s => s.ServiceEstimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceEstimatePrice == null)
            {
                return NotFound();
            }

            return View(serviceEstimatePrice);
        }

        // POST: ServiceEstimatePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceEstimatePrice == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceEstimatePrice'  is null.");
            }
            var serviceEstimatePrice = await _context.ServiceEstimatePrice.FindAsync(id);
            if (serviceEstimatePrice != null)
            {
                _context.ServiceEstimatePrice.Remove(serviceEstimatePrice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceEstimatePriceExists(int id)
        {
          return _context.ServiceEstimatePrice.Any(e => e.Id == id);
        }
    }
}
