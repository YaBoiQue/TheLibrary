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
            customerCommentViewModel ??= new CustomerCommentViewModel();

            customerCommentViewModel.CustomerComments = await _customerCommentRepository.GetAll(new GetCustomerCommentsFilteredBy(filterBy), new GetCustomerCommentsOrderedBy(orderBy));
            return View(customerCommentViewModel);
        }

        // GET: CustomerComments/Details/5
        public async Task<IActionResult> Details(CustomerCommentViewModel customerCommentViewModel)
        {
            customerCommentViewModel ??= new CustomerCommentViewModel();

            var customerComment = await _customerCommentRepository.GetById(new GetCustomerCommentById(customerCommentViewModel.Id));

            customerCommentViewModel.Id = customerComment.Id;
            customerCommentViewModel.Contents = customerComment.Contents;
            customerCommentViewModel.DateCreated = customerComment.DateCreated;
            customerCommentViewModel.CustomerId = customerComment.CustomerId;

            return customerComment == new CustomerComment() ? NotFound() : View(customerCommentViewModel);
        }

        // GET: CustomerComments/Create
        public IActionResult Create(CustomerCommentViewModel customerCommentViewModel)
        {
            customerCommentViewModel ??= new CustomerCommentViewModel();

            return View();
        }

        // POST: CustomerComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed([Bind("CustomerId,Id,Contents,DateCreated")] CustomerCommentViewModel customerCommentViewModel)
        {
            if (ModelState.IsValid)
            {
                _ = await _customerCommentRepository.Insert(customerCommentViewModel);
                return RedirectToAction(nameof(Index));
            }

            customerCommentViewModel ??= new CustomerCommentViewModel();

            return View(customerCommentViewModel);
        }

        // GET: CustomerComments/Edit/5
        public async Task<IActionResult> Edit(CustomerCommentViewModel customerCommentViewModel)
        {
            customerCommentViewModel ??= new CustomerCommentViewModel();

            CustomerComment? customerComment = await _customerCommentRepository.GetById(new GetCustomerCommentById(customerCommentViewModel.Id));
            if (customerComment == null)
            {
                return NotFound();
            }

            customerCommentViewModel.Id = customerComment.Id;
            customerCommentViewModel.Contents = customerComment.Contents;
            customerCommentViewModel.DateCreated = customerComment.DateCreated;
            customerCommentViewModel.CustomerId = customerComment.CustomerId;

            return View(customerCommentViewModel);
        }

        // POST: CustomerComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Id,Contents,DateCreated")] CustomerCommentViewModel customerCommentViewModel)
        {
            if (id != customerCommentViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = await _customerCommentRepository.Update(new GetCustomerCommentById(customerCommentViewModel.Id), customerCommentViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await CustomerCommentExists(customerCommentViewModel)))
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

            customerCommentViewModel ??= new CustomerCommentViewModel();

            return View(customerCommentViewModel);
        }

        // GET: CustomerComments/Delete/5
        public async Task<IActionResult> Delete(CustomerCommentViewModel customerCommentViewModel)
        {
            customerCommentViewModel ??= new CustomerCommentViewModel();

            CustomerComment? customerComment = await _customerCommentRepository.GetById(new GetCustomerCommentById(customerCommentViewModel.Id));

            customerCommentViewModel.Id = customerComment.Id;
            customerCommentViewModel.Contents = customerComment.Contents;
            customerCommentViewModel.DateCreated = customerComment.DateCreated;
            customerCommentViewModel.CustomerId = customerComment.CustomerId;

            return customerComment == new CustomerComment() ? NotFound() : View(customerCommentViewModel);
        }

        // POST: CustomerComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(CustomerCommentViewModel customerCommentViewModel)
        {

            CustomerComment? customerComment = await _customerCommentRepository.GetById(new GetCustomerCommentById(customerCommentViewModel.Id));
            if (customerComment != null)
            {
                _ = _customerCommentRepository.Delete(new GetCustomerCommentById(customerComment.Id));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CustomerCommentExists(CustomerCommentViewModel customerCommentViewModel)
        {
            if (await _customerCommentRepository.GetById(new GetCustomerCommentById(customerCommentViewModel.Id)) != new CustomerComment())
                return true;

            return false;
        }
    }
}
