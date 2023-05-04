using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class ServiceEstimatesController : Controller
    {
        private readonly IServiceEstimateRepository _repo;

        public ServiceEstimatesController(IServiceEstimateRepository repo)
        {
            _repo = repo;
        }

        // GET: ServiceEstimates
        public async Task<IActionResult> Index(ServiceEstimateViewModel serviceEstimateViewModel)
        {
            serviceEstimateViewModel.SortByLevel = (serviceEstimateViewModel.SortBy == SortByParameter.LevelASC)
                ? SortByParameter.LevelDESC : SortByParameter.LevelASC;
            serviceEstimateViewModel.SortByValue = (serviceEstimateViewModel.SortBy == SortByParameter.ValueASC)
                ? SortByParameter.ValueDESC : SortByParameter.ValueASC;
            serviceEstimateViewModel.ReturnController = "ServiceEstimates";
            serviceEstimateViewModel.ReturnAction = "Index";
            serviceEstimateViewModel.ReturnId = "";
            serviceEstimateViewModel.ServiceEstimates = await _repo.GetAll(
                new GetServiceEstimatesFilteredBy(serviceEstimateViewModel.FilterBy),
                new GetServiceEstimatesOrderedBy(serviceEstimateViewModel.SortBy));

            return View(serviceEstimateViewModel);
        }

        // GET: ServiceEstimates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceEstimate == null)
            {
                return NotFound();
            }

            ServiceEstimate? serviceEstimate = await _context.ServiceEstimate
                .Include(s => s.Estimate)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            return serviceEstimate == null ? NotFound() : View(serviceEstimate);
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
                _ = _context.Add(serviceEstimate);
                _ = await _context.SaveChangesAsync();
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

            ServiceEstimate? serviceEstimate = await _context.ServiceEstimate.FindAsync(id);
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
                    _ = _context.Update(serviceEstimate);
                    _ = await _context.SaveChangesAsync();
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

            ServiceEstimate? serviceEstimate = await _context.ServiceEstimate
                .Include(s => s.Estimate)
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            return serviceEstimate == null ? NotFound() : View(serviceEstimate);
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
            ServiceEstimate? serviceEstimate = await _context.ServiceEstimate.FindAsync(id);
            if (serviceEstimate != null)
            {
                _ = _context.ServiceEstimate.Remove(serviceEstimate);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceEstimateExists(int id)
        {
            return _context.ServiceEstimate.Any(e => e.Id == id);
        }
    }
}
