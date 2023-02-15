using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Controllers
{
    public class ShopSuppliesController : Controller
    {
        private readonly IShopSupplyRepository _repo;

        public ShopSuppliesController(IShopSupplyRepository repo)
        {
            _repo = repo;
        }

        // GET: ShopSupplies
        public async Task<IActionResult> Index(ShopSupplyViewModel viewModel)
        {
            viewModel.ShopSupplies = await _repo.GetAll(new GetShopSuppliesFilteredBy(viewModel.FilterBy), new GetShopSuppliesOrderedBy(viewModel.SortBy));
            return View(viewModel);
        }

        // GET: ShopSupplies/Details/5
        public async Task<IActionResult> Details(ShopSupplyViewModel viewModel)
        {
            viewModel ??= new ShopSupplyViewModel();

            ShopSupply? shopSupply = await _repo.GetById(new GetShopSupplyById(viewModel.Id));

            viewModel.Name = shopSupply.Name;
            viewModel.Description = shopSupply.Description;
            viewModel.Value = shopSupply.Value;

            return shopSupply == new ShopSupply() ? NotFound() : View(viewModel);
        }

        // GET: ShopSupplies/Create
        public IActionResult Create(ShopSupplyViewModel viewModel)
        {
            return View(viewModel);
        }

        // POST: ShopSupplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed([Bind("EstimateId,Name,Description,Id,Value")] ShopSupplyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _ = await _repo.Insert(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ShopSupplies/Edit/5
        public async Task<IActionResult> Edit(ShopSupplyViewModel viewModel)
        {
            viewModel ??= new ShopSupplyViewModel();

            ShopSupply? shopSupply = await _repo.GetById(new GetShopSupplyById(viewModel.Id));
            return shopSupply == new ShopSupply() ? NotFound() : View(viewModel);
        }

        // POST: ShopSupplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstimateId,Name,Description,Id,Value")] ShopSupplyViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ = await _repo.Update(new GetShopSupplyById(viewModel.Id), viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await ShopSupplyExists(viewModel.Id)))
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

        // GET: ShopSupplies/Delete/5
        public async Task<IActionResult> Delete(ShopSupplyViewModel viewModel)
        {
            viewModel ??= new ShopSupplyViewModel();

            ShopSupply? shopSupply = await _repo.GetById(new GetShopSupplyById(viewModel.Id));
            return shopSupply == new ShopSupply() ? NotFound() : View(viewModel);
        }

        // POST: ShopSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ShopSupplyViewModel viewModel)
        {
            ShopSupply? shopSupply = await _repo.GetById(new GetShopSupplyById(viewModel.Id));
            if (shopSupply != new ShopSupply())
            {
                await _repo.Delete(new GetShopSupplyById(viewModel.Id));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ShopSupplyExists(int id)
        {
            return await _repo.GetById(new GetShopSupplyById(id)) != new ShopSupply();
        }
    }
}
