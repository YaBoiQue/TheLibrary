using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class ServicePricesController : Controller
    {
        private readonly IServicePriceRepository _servicePriceRepository;
        private readonly IServiceRepository _serviceRepository;

        public ServicePricesController(IServicePriceRepository servicePriceRepository, IServiceRepository serviceRepository)
        {
            _servicePriceRepository = servicePriceRepository;
            _serviceRepository = serviceRepository;
        }

        // GET: ServicePrices
        public async Task<IActionResult> Index(ServicePriceViewModel servicePriceViewModel)
        {
            servicePriceViewModel.SortByLevel = (servicePriceViewModel.SortBy == SortByParameter.LevelASC) ? SortByParameter.LevelDESC : SortByParameter.LevelASC;

            servicePriceViewModel.SortByValue = (servicePriceViewModel.SortBy == SortByParameter.ValueASC) ? SortByParameter.ValueDESC : SortByParameter.ValueASC;

            servicePriceViewModel.ServicePrices = await _servicePriceRepository.GetServicePrices(
                new GetServicePricesFilteredBy(servicePriceViewModel.FilterBy),
                new GetServicePricesOrderedBy(servicePriceViewModel.SortBy));

            return View(servicePriceViewModel);
        }

        // GET: ServicePrices/Details/5
        public async Task<IActionResult> Details(int? id, string returnController, string returnAction, string returnId)
        {
            ServicePriceViewModel servicePriceViewModel;

            if (id == null)
            {
                return NotFound();
            }

            servicePriceViewModel = new(await _servicePriceRepository.GetServicePriceById(new GetServicePriceById((int)id)))
            {
                ReturnController = returnController,
                ReturnAction = returnAction,
                ReturnId = returnId
            };

            return View(servicePriceViewModel);
        }

        // GET: ServicePrices/Create
        public async Task<IActionResult> Create([Bind("Id,Name,ReturnController,ReturnAction,ReturnId")] ServiceViewModel serviceViewModel)
        {
            ServicePriceViewModel servicePriceViewModel = new()
            {
                ServiceId = serviceViewModel.Id,
                ReturnController = serviceViewModel.ReturnController,
                ReturnAction = serviceViewModel.ReturnAction,
                ReturnId = serviceViewModel.ReturnId,
                Service = new Service()
                {
                    Name = serviceViewModel.Name,
                    Id = serviceViewModel.Id
                }
            };

            var services = await _serviceRepository.GetServices(
                new GetServicesFilteredBy(serviceViewModel.FilterBy), 
                new GetServicesOrderedBy(serviceViewModel.SortBy));

            servicePriceViewModel.Services = new List<SelectListItem>();
            foreach (var item in services)
            {
                servicePriceViewModel.Services.Add(new SelectListItem { Text = item.Name.Trim(), Value = item.Id.ToString() });
            }

            return View(servicePriceViewModel);
        }

        // POST: ServicePrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Description,Level,Id,Value,ReturnController,ReturnAction,ReturnId")] ServicePriceViewModel servicePriceViewModel)
        {
            if (servicePriceViewModel == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _ = await _servicePriceRepository.InsertServicePrice(servicePriceViewModel);


                return servicePriceViewModel.ReturnAction == null
                    ? RedirectToAction(nameof(Index))
                    : (IActionResult)RedirectToAction(servicePriceViewModel.ReturnAction, servicePriceViewModel.ReturnController, servicePriceViewModel.ReturnId);
            }

            return View();
        }

        // GET: ServicePrices/Edit/5
        public async Task<IActionResult> Edit(int? id, string returnController, string returnAction, string returnId)
        {
            ServicePriceViewModel servicePriceViewModel;

            if (id == null)
            {
                return NotFound();
            }

            servicePriceViewModel = new(await _servicePriceRepository.GetServicePriceById(new GetServicePriceById((int)id)))
            {
                ReturnController = returnController,
                ReturnAction = returnAction,
                ReturnId = returnId
            };

            return servicePriceViewModel.Id == 0 ? NotFound() : View(servicePriceViewModel);
        }

        // POST: ServicePrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Description,Level,Id,Value,ReturnController,ReturnAction,ReturnId")] ServicePriceViewModel servicePriceViewModel)
        {
            if (id != servicePriceViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                ServicePrice updatedStudent = await _servicePriceRepository.UpdateServicePrice(new GetServicePriceById(id), servicePriceViewModel);
                if (updatedStudent == null)
                {
                    return NotFound();
                }

                return servicePriceViewModel.ReturnAction == null
                    ? RedirectToAction(nameof(Index))
                    : (IActionResult)RedirectToAction(servicePriceViewModel.ReturnAction, servicePriceViewModel.ReturnController, servicePriceViewModel.ReturnId);
            }
            return View(servicePriceViewModel);

        }

        // GET: ServicePrices/Delete/5
        public async Task<IActionResult> Delete(int? id, string returnController, string returnAction, string returnId)
        {
            ServicePriceViewModel servicePriceViewModel;

            if (id == null)
            {
                return NotFound();
            }

            servicePriceViewModel = new(await _servicePriceRepository.GetServicePriceById(new GetServicePriceById((int)id)))
            {
                ReturnController = returnController,
                ReturnAction = returnAction,
                ReturnId = returnId
            };

            return servicePriceViewModel.Id == 0 ? NotFound() : View(servicePriceViewModel);
        }

        // POST: ServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string returnController, string returnAction, string returnId)
        {
            await _servicePriceRepository.DeleteServicePrice(new GetServicePriceById(id));

            return returnAction == null ? RedirectToAction(nameof(Index)) : (IActionResult)RedirectToAction(returnAction, returnController, returnId);
        }
    }
}
