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
    public class EstimateCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstimateCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstimateComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EstimateComment.Include(e => e.Estimate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EstimateComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstimateComment == null)
            {
                return NotFound();
            }

            var estimateComment = await _context.EstimateComment
                .Include(e => e.Estimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estimateComment == null)
            {
                return NotFound();
            }

            return View(estimateComment);
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
                _context.Add(estimateComment);
                await _context.SaveChangesAsync();
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

            var estimateComment = await _context.EstimateComment.FindAsync(id);
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
                    _context.Update(estimateComment);
                    await _context.SaveChangesAsync();
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

            var estimateComment = await _context.EstimateComment
                .Include(e => e.Estimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estimateComment == null)
            {
                return NotFound();
            }

            return View(estimateComment);
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
            var estimateComment = await _context.EstimateComment.FindAsync(id);
            if (estimateComment != null)
            {
                _context.EstimateComment.Remove(estimateComment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstimateCommentExists(int id)
        {
          return _context.EstimateComment.Any(e => e.Id == id);
        }
    }
}
