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
    public class ServiceEstimatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceEstimatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceEstimates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ServiceEstimate.Include(s => s.Estimate).Include(s => s.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceEstimates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceEstimate == null)
            {
                return NotFound();
            }

            var serviceEstimate = await _context.ServiceEstimate
                .Include(s => s.Estimate)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceEstimate == null)
            {
                return NotFound();
            }

            return View(serviceEstimate);
        }

        // GET: ServiceEstimates/Create
        public IActionResult Create()
        {
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description");
            return View();
        }

        // POST: ServiceEstimates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceId,EstimateId,AdjustedHours")] ServiceEstimate serviceEstimate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceEstimate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", serviceEstimate.EstimateId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description", serviceEstimate.ServiceId);
            return View(serviceEstimate);
        }

        // GET: ServiceEstimates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceEstimate == null)
            {
                return NotFound();
            }

            var serviceEstimate = await _context.ServiceEstimate.FindAsync(id);
            if (serviceEstimate == null)
            {
                return NotFound();
            }
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", serviceEstimate.EstimateId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description", serviceEstimate.ServiceId);
            return View(serviceEstimate);
        }

        // POST: ServiceEstimates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceId,EstimateId,AdjustedHours")] ServiceEstimate serviceEstimate)
        {
            if (id != serviceEstimate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceEstimate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceEstimateExists(serviceEstimate.Id))
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
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", serviceEstimate.EstimateId);
            ViewData["ServiceId"] = new SelectList(_context.Service, "Id", "Description", serviceEstimate.ServiceId);
            return View(serviceEstimate);
        }

        // GET: ServiceEstimates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceEstimate == null)
            {
                return NotFound();
            }

            var serviceEstimate = await _context.ServiceEstimate
                .Include(s => s.Estimate)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceEstimate == null)
            {
                return NotFound();
            }

            return View(serviceEstimate);
        }

        // POST: ServiceEstimates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceEstimate == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceEstimate'  is null.");
            }
            var serviceEstimate = await _context.ServiceEstimate.FindAsync(id);
            if (serviceEstimate != null)
            {
                _context.ServiceEstimate.Remove(serviceEstimate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceEstimateExists(int id)
        {
          return _context.ServiceEstimate.Any(e => e.Id == id);
        }
    }
}
