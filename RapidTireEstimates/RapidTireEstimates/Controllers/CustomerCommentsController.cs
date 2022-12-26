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
    public class CustomerCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomerComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomerComment.Include(c => c.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomerComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerComment == null)
            {
                return NotFound();
            }

            var customerComment = await _context.CustomerComment
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerComment == null)
            {
                return NotFound();
            }

            return View(customerComment);
        }

        // GET: CustomerComments/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name");
            return View();
        }

        // POST: CustomerComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Id,Contents,DateCreated")] CustomerComment customerComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", customerComment.CustomerId);
            return View(customerComment);
        }

        // GET: CustomerComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerComment == null)
            {
                return NotFound();
            }

            var customerComment = await _context.CustomerComment.FindAsync(id);
            if (customerComment == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", customerComment.CustomerId);
            return View(customerComment);
        }

        // POST: CustomerComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Id,Contents,DateCreated")] CustomerComment customerComment)
        {
            if (id != customerComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerCommentExists(customerComment.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name", customerComment.CustomerId);
            return View(customerComment);
        }

        // GET: CustomerComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerComment == null)
            {
                return NotFound();
            }

            var customerComment = await _context.CustomerComment
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerComment == null)
            {
                return NotFound();
            }

            return View(customerComment);
        }

        // POST: CustomerComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerComment == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CustomerComment'  is null.");
            }
            var customerComment = await _context.CustomerComment.FindAsync(id);
            if (customerComment != null)
            {
                _context.CustomerComment.Remove(customerComment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerCommentExists(int id)
        {
          return _context.CustomerComment.Any(e => e.Id == id);
        }
    }
}
