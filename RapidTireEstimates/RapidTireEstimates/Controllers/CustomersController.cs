using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Repositories;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Customers
        public async Task<IActionResult> Index(CustomerViewModel customerViewModel)
        {
            customerViewModel.SortByName = (customerViewModel.SortBy == SortByParameter.NameASC) ? SortByParameter.NameDESC : SortByParameter.NameASC;

            customerViewModel.SortByPhoneNumber = (customerViewModel.SortBy == SortByParameter.PhoneNumberASC) ? SortByParameter.PhoneNumberDESC : SortByParameter.PhoneNumberASC;

            customerViewModel.Customers = await _customerRepository.GetAll(
                new GetCustomersFilteredBy(customerViewModel.FilterBy),
                new GetCustomersOrderedBy(customerViewModel.SortBy));

            return View(customerViewModel);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var customerViewModel = new CustomerViewModel(await _customerRepository.GetById(new GetCustomerById((int)id)));
            return customerViewModel == null ? NotFound() : View(customerViewModel);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            CustomerViewModel customerViewModel = new();

            return View(customerViewModel);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber")] CustomerViewModel customerViewModel)
        {
            if (customerViewModel == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _customerRepository.Insert(customerViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(customerViewModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer? customer = await _customerRepository.GetById(new GetCustomerById((int)id));

            if (customer == null)
            {
                return NotFound();
            }

            CustomerViewModel customerViewModel = new(customer);

            return View(customerViewModel);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber")] CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _customerRepository.Update(new GetCustomerById((int)id), customerViewModel);

                return View(customerViewModel);
            }

            return View(customerViewModel);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer? customer = await _customerRepository.GetById(new GetCustomerById((int)id));
            return customer == null ? NotFound() : View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerRepository.Delete(new GetCustomerById((int)id));

            return RedirectToAction(nameof(Index));
        }
    }
}
