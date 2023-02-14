using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Repositories;
using RapidTireEstimates.ViewModels;
using RapidTireEstimates.Specifications;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class CustomerCommentsController : Controller
    {
        private readonly ICustomerCommentRepository _customerCommentRepository;
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommentsController(ICustomerCommentRepository customerCommentRepository, ICustomerRepository customerRepository)
        {
            _customerCommentRepository = customerCommentRepository;
            _customerRepository = customerRepository;
        }

        // GET: CustomerComments
        public async Task<IActionResult> Index(CustomerCommentViewModel customerCommentViewModel)
        {
            string filterBy = "";
            SortByParameter orderBy = SortByParameter.NameASC;
            if (customerCommentViewModel != null)
            {
                filterBy = customerCommentViewModel.FilterBy;
                orderBy = customerCommentViewModel.SortBy;
            }

            customerCommentViewModel.CustomerComments = await _customerCommentRepository.GetAll(new GetCustomerCommentsFilteredBy(filterBy), new GetCustomerCommentsOrderedBy(orderBy));
            return View(customerCommentViewModel);
        }

        // GET: CustomerComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerComment == null)
            {
                return NotFound();
            }

            CustomerComment? customerComment = await _context.CustomerComment
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            return customerComment == null ? NotFound() : View(customerComment);
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
                _ = _context.Add(customerComment);
                _ = await _context.SaveChangesAsync();
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

            CustomerComment? customerComment = await _context.CustomerComment.FindAsync(id);
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
                    _ = _context.Update(customerComment);
                    _ = await _context.SaveChangesAsync();
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

            CustomerComment? customerComment = await _context.CustomerComment
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            return customerComment == null ? NotFound() : View(customerComment);
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
            CustomerComment? customerComment = await _context.CustomerComment.FindAsync(id);
            if (customerComment != null)
            {
                _ = _context.CustomerComment.Remove(customerComment);
            }

            _ = await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerCommentExists(int id)
        {
            return _context.CustomerComment.Any(e => e.Id == id);
        }
    }
}
