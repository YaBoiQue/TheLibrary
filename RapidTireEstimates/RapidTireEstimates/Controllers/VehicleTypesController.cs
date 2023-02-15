using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using System.Security.Cryptography.Xml;

namespace RapidTireEstimates.Controllers
{
    public class VehicleTypesController : Controller
    {
        private readonly IVehicleTypeRepository _repository;

        public VehicleTypesController(IVehicleTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index(VehicleTypeViewModel viewModel)
        {
            viewModel ??= new VehicleTypeViewModel();

            viewModel.VehicleTypes = await _repository.GetAll(new GetVehicleTypesFilteredBy(viewModel.FilterBy), new GetVehicleTypesOrderedBy(viewModel.SortBy));

            return View(viewModel);
        }

        // GET: VehicleTypes/Details/5
        public async Task<IActionResult> Details(VehicleTypeViewModel viewModel)
        {
            viewModel ??= new VehicleTypeViewModel();

            var vehicleType = await _repository.GetById(new GetVehicleTypeById(viewModel.Id));

            viewModel.Name = vehicleType.Name;

            return vehicleType == new VehicleType() ? NotFound() : View(viewModel);
        }

        // GET: VehicleTypes/Create
        public IActionResult Create(VehicleTypeViewModel viewModel, int dif = 0)
        {
            return View(viewModel);
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VehicleTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _ = await _repository.Insert(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(VehicleTypeViewModel viewModel)
        {
            if (viewModel == null)
            {
                return NotFound();
            }

            VehicleType vehicleType = await _repository.GetById(new GetVehicleTypeById(viewModel.Id));

            viewModel.Name = vehicleType.Name;

            return vehicleType == new VehicleType() ? NotFound() : View(viewModel);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VehicleTypeViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = await _repository.Update(new GetVehicleTypeById(id), viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await VehicleTypeExists(viewModel.Id)))
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

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(VehicleTypeViewModel viewModel)
        {
            if (viewModel == null)
            {
                return NotFound();
            }

            VehicleType? vehicleType = await _repository.GetById(new GetVehicleTypeById(viewModel.Id));

            return vehicleType == new VehicleType() ? NotFound() : View(viewModel);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(VehicleTypeViewModel viewModel)
        {
            if (_repository == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VehicleType'  is null.");
            }

            viewModel ??= new VehicleTypeViewModel();

            VehicleType? vehicleType = await _repository.GetById(new GetVehicleTypeById(viewModel.Id));

            if (vehicleType != new VehicleType())
            {
                await _repository.Delete(new GetVehicleTypeById(viewModel.Id));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VehicleTypeExists(int id)
        {
            return (await _repository.GetById(new GetVehicleTypeById(id)) == new VehicleType());
        }
    }
}
