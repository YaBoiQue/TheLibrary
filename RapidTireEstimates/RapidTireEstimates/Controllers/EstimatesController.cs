using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using System.Reflection.Metadata;
using static RapidTireEstimates.Helpers.Constants;
using ViewModel = RapidTireEstimates.ViewModels.EstimateViewModel;

namespace RapidTireEstimates.Controllers
{
    public class EstimatesController : Controller
    {
        
        private readonly IEstimateRepository _estimateRepository;

        public EstimatesController(IEstimateRepository estimateRepository)
        {
            _estimateRepository = estimateRepository;
        }

        // GET: Estimates
        public async Task<IActionResult> Index(ViewModel viewModel)
        {
            viewModel.SortByValue = (viewModel.SortBy == SortByParameter.ValueASC)
                ? SortByParameter.ValueDESC : SortByParameter.ValueASC;
            viewModel.SortByLevel = (viewModel.SortBy == SortByParameter.LevelASC)
                ? SortByParameter.LevelDESC : SortByParameter.LevelASC;
            viewModel.ReturnController = "Estimates";
            viewModel.ReturnAction = "Index";
            viewModel.ReturnId = "";
            viewModel.Estimates = await _estimateRepository.GetAll(
                new GetEstimatesFilteredBy(viewModel.FilterBy),
                new GetEstimatesOrderedBy(viewModel.SortBy));

            return View(viewModel);
        }

        // GET: Estimates/Details/5
        public async Task<IActionResult> Details(ViewModel viewModel)
        {
            viewModel ??= new ViewModel();

            viewModel.Estimate = await _estimateRepository.GetById(new GetEstimateById(viewModel.Id));

            return viewModel.Estimate == null ? NotFound() : View(viewModel);
        }

        // GET: Estimates/Create
        public IActionResult Create(ViewModel viewModel)
        {
            viewModel ??= new ViewModel();

            viewModel.

            return View();
        }

        // POST: Estimates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,VehicleId,DateFinished,ShopToolAmount,FinalPrice")] Estimate estimate)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(estimate);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", estimate.CustomerId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Make", estimate.VehicleId);
            return View(estimate);
        }

        // GET: Estimates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estimate == null)
            {
                return NotFound();
            }

            Estimate? estimate = await _context.Estimate.FindAsync(id);
            if (estimate == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", estimate.CustomerId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Make", estimate.VehicleId);
            return View(estimate);
        }

        // POST: Estimates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,VehicleId,DateFinished,ShopToolAmount,FinalPrice")] Estimate estimate)
        {
            if (id != estimate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(estimate);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstimateExists(estimate.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", estimate.CustomerId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "Id", "Make", estimate.VehicleId);
            return View(estimate);
        }

        // GET: Estimates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estimate == null)
            {
                return NotFound();
            }

            Estimate? estimate = await _context.Estimate
                .Include(e => e.Customer)
                .Include(e => e.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            return estimate == null ? NotFound() : View(estimate);
        }

        // POST: Estimates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estimate == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Estimate'  is null.");
            }
            Estimate? estimate = await _context.Estimate.FindAsync(id);
            if (estimate != null)
            {
                _ = _context.Estimate.Remove(estimate);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstimateExists(int id)
        {
            return _context.Estimate.Any(e => e.Id == id);
        }
    }
}
