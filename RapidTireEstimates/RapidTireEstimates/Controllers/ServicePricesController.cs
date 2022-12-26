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
    public class ServicePricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicePricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicePrices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServicePrice.Include(s => s.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServicePrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicePrice == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrice
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(servicePrice);
        }

        // GET: ServicePrices/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description");
            return View();
        }

        // POST: ServicePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Description,Level,Id,Value")] ServicePrice servicePrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicePrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description", servicePrice.ServiceId);
            return View(servicePrice);
        }

        // GET: ServicePrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicePrice == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrice.FindAsync(id);
            if (servicePrice == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description", servicePrice.ServiceId);
            return View(servicePrice);
        }

        // POST: ServicePrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Description,Level,Id,Value")] ServicePrice servicePrice)
        {
            if (id != servicePrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePriceExists(servicePrice.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description", servicePrice.ServiceId);
            return View(servicePrice);
        }

        // GET: ServicePrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicePrice == null)
            {
                return NotFound();
            }

            var servicePrice = await _context.ServicePrice
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicePrice == null)
            {
                return NotFound();
            }

            return View(servicePrice);
        }

        // POST: ServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicePrice == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServicePrice'  is null.");
            }
            var servicePrice = await _context.ServicePrice.FindAsync(id);
            if (servicePrice != null)
            {
                _context.ServicePrice.Remove(servicePrice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicePriceExists(int id)
        {
          return _context.ServicePrice.Any(e => e.Id == id);
        }
    }
}
