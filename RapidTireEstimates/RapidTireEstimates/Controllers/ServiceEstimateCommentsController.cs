using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Controllers
{
    public class ServiceEstimateCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceEstimateCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceEstimateComments
        public async Task<IActionResult> Index()
        {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<ServiceEstimateComment, ServiceEstimate> applicationDbContext = _context.ServiceEstimateComment.Include(s => s.ServiceEstimate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ServiceEstimateComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceEstimateComment == null)
            {
                return NotFound();
            }

            ServiceEstimateComment? serviceEstimateComment = await _context.ServiceEstimateComment
                .Include(s => s.ServiceEstimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            return serviceEstimateComment == null ? NotFound() : View(serviceEstimateComment);
        }

        // GET: ServiceEstimateComments/Create
        public IActionResult Create()
        {
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id");
            return View();
        }

        // POST: ServiceEstimateComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceEstimateId,Id,Contents,DateCreated")] ServiceEstimateComment serviceEstimateComment)
        {
            if (ModelState.IsValid)
            {
                _ = _context.Add(serviceEstimateComment);
                _ = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id", serviceEstimateComment.ServiceEstimateId);
            return View(serviceEstimateComment);
        }

        // GET: ServiceEstimateComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceEstimateComment == null)
            {
                return NotFound();
            }

            ServiceEstimateComment? serviceEstimateComment = await _context.ServiceEstimateComment.FindAsync(id);
            if (serviceEstimateComment == null)
            {
                return NotFound();
            }
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id", serviceEstimateComment.ServiceEstimateId);
            return View(serviceEstimateComment);
        }

        // POST: ServiceEstimateComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceEstimateId,Id,Contents,DateCreated")] ServiceEstimateComment serviceEstimateComment)
        {
            if (id != serviceEstimateComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = _context.Update(serviceEstimateComment);
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceEstimateCommentExists(serviceEstimateComment.Id))
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
            ViewData["ServiceEstimateId"] = new SelectList(_context.ServiceEstimate, "Id", "Id", serviceEstimateComment.ServiceEstimateId);
            return View(serviceEstimateComment);
        }

        // GET: ServiceEstimateComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceEstimateComment == null)
            {
                return NotFound();
            }

            ServiceEstimateComment? serviceEstimateComment = await _context.ServiceEstimateComment
                .Include(s => s.ServiceEstimate)
                .FirstOrDefaultAsync(m => m.Id == id);
            return serviceEstimateComment == null ? NotFound() : View(serviceEstimateComment);
        }

        // POST: ServiceEstimateComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceEstimateComment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceEstimateComment'  is null.");
            }
            ServiceEstimateComment? serviceEstimateComment = await _context.ServiceEstimateComment.FindAsync(id);
            if (serviceEstimateComment != null)
            {
                _ = _context.ServiceEstimateComment.Remove(serviceEstimateComment);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceEstimateCommentExists(int id)
        {
            return _context.ServiceEstimateComment.Any(e => e.Id == id);
        }
    }
}
