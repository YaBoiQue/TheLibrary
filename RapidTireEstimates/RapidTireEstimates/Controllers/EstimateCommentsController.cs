using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Repositories;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class EstimateCommentsController : Controller
    {
        private readonly IEstimateCommentRepository _estimateCommentRepository;

        public EstimateCommentsController(IEstimateCommentRepository estimateCommentRepository)
        {
            _estimateCommentRepository = estimateCommentRepository;
        }

        // GET: EstimateComments
        public async Task<IActionResult> Index(EstimateCommentViewModel estimateCommentViewModel)
        {
            string filterBy = "";
            SortByParameter orderBy = SortByParameter.NameASC;
            if (estimateCommentViewModel != null)
            {
                filterBy = estimateCommentViewModel.FilterBy;
                orderBy = estimateCommentViewModel.SortBy;
            }
            estimateCommentViewModel ??= new EstimateCommentViewModel();

            estimateCommentViewModel.EstimateComments = await _estimateCommentRepository.GetAll(new GetEstimateCommentsFilteredBy(filterBy), new GetEstimateCommentsOrderedBy(orderBy));
            return View(estimateCommentViewModel);
        }

        // GET: EstimateComments/Details/5
        public async Task<IActionResult> Details(EstimateCommentViewModel estimateCommentViewModel)
        {
            estimateCommentViewModel ??= new EstimateCommentViewModel();

            var estimateComment = await _estimateCommentRepository.GetById(new GetEstimateCommentById(estimateCommentViewModel.Id));

            estimateCommentViewModel.Id = estimateComment.Id;
            estimateCommentViewModel.Contents = estimateComment.Contents;
            estimateCommentViewModel.DateCreated = estimateComment.DateCreated;
            estimateCommentViewModel.EstimateId = estimateComment.Estimate.Id;

            return estimateComment == new EstimateComment() ? NotFound() : View(estimateCommentViewModel);
        }

        // GET: EstimateComments/Create
        public IActionResult Create()
        {
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id");
            return View();
        }

        // POST: EstimateComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstimateId,Id,Contents,DateCreated")] EstimateComment estimateComment)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(estimateComment);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", estimateComment.EstimateId);
            return View(estimateComment);
        }

        // GET: EstimateComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstimateComment == null)
            {
                return NotFound();
            }

            EstimateComment? estimateComment = await _context.EstimateComment.FindAsync(id);
            if (estimateComment == null)
            {
                return NotFound();
            }
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", estimateComment.EstimateId);
            return View(estimateComment);
        }

        // POST: EstimateComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstimateId,Id,Contents,DateCreated")] EstimateComment estimateComment)
        {
            if (id != estimateComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(estimateComment);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstimateCommentExists(estimateComment.Id))
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
            ViewData["EstimateId"] = new SelectList(_context.Estimate, "Id", "Id", estimateComment.EstimateId);
            return View(estimateComment);
        }

        // GET: EstimateComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstimateComment == null)
            {
                return NotFound();
            }

            EstimateComment? estimateComment = await _context.EstimateComment
                .Include(e => e.Estimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            return estimateComment == null ? NotFound() : View(estimateComment);
        }

        // POST: EstimateComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstimateComment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EstimateComment'  is null.");
            }
            EstimateComment? estimateComment = await _context.EstimateComment.FindAsync(id);
            if (estimateComment != null)
            {
                _ = _context.EstimateComment.Remove(estimateComment);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstimateCommentExists(int id)
        {
            return _context.EstimateComment.Any(e => e.Id == id);
        }
    }
}
