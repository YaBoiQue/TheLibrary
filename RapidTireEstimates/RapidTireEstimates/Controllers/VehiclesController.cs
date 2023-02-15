using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(VehicleViewModel viewModel)
        {
            viewModel.Vehicles = await _repository.GetAll(new GetVehiclesFilteredBy(viewModel.FilterBy), new GetVehiclesOrderedBy(viewModel.SortBy));
            return View(viewModel);
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(VehicleViewModel viewModel)
        {
            viewModel ??= new VehicleViewModel();

            Vehicle? vehicle = await _repository.GetById(new GetVehicleById(viewModel.Id));
            return vehicle == new Vehicle() ? NotFound() : View(viewModel);
        }

        // GET: Vehicles/Create
        public IActionResult Create(VehicleViewModel viewModel)
        {
            viewModel ??= new VehicleViewModel();
            return View(viewModel);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed([Bind("Id,CustomerId,Make,Model,Year")] VehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _ = await _repository.Insert(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(VehicleViewModel viewModel)
        {
           viewModel ??= new VehicleViewModel();

            Vehicle? vehicle = await _repository.GetById(new GetVehicleById(viewModel.Id));
            if (vehicle == new Vehicle())
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,Make,Model,Year")] VehicleViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = await _repository.Update(new GetVehicleById(id), viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await VehicleExists(viewModel.Id)))
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
            return View(viewModel);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(VehicleViewModel viewModel)
        {
            viewModel ??= new VehicleViewModel();

            Vehicle? vehicle = await _repository.GetById(new GetVehicleById(viewModel.Id));
            return vehicle == new Vehicle() ? NotFound() : View(viewModel);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(VehicleViewModel viewModel)
        {
            viewModel ??= new VehicleViewModel();
            Vehicle? vehicle = await _repository.GetById(new GetVehicleById(viewModel.Id));
            if (vehicle != new Vehicle())
            {
                await _repository.Delete(new GetVehicleById(viewModel.Id));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VehicleExists(int id)
        {
            return await _repository.GetById(new GetVehicleById(id)) != new Vehicle();
        }
    }
}
