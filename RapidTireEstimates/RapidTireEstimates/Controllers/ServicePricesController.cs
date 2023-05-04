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

            servicePriceViewModel.ServicePrices = await _servicePriceRepository.GetAll(
                new GetServicePricesFilteredBy(servicePriceViewModel.FilterBy),
                new GetServicePricesOrderedBy(servicePriceViewModel.SortBy));

            return View(servicePriceViewModel);
        }

        // GET: ServicePrices/Details/5
        public async Task<IActionResult> Details(ServicePriceViewModel viewModel, string returnController, string returnAction, string returnId)
        {
            viewModel = new(await _servicePriceRepository.GetById(new GetServicePriceById(viewModel.Id)))
            {
                ReturnController = returnController,
                ReturnAction = returnAction,
                ReturnId = returnId
            };

            return View(viewModel);
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

            var services = await _serviceRepository.GetAll(
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
                _ = await _servicePriceRepository.Insert(servicePriceViewModel);


                return servicePriceViewModel.ReturnAction == null
                    ? RedirectToAction(nameof(Index))
                    : (IActionResult)RedirectToAction(servicePriceViewModel.ReturnAction, servicePriceViewModel.ReturnController, servicePriceViewModel.ReturnId);
            }

            return View();
        }

        // GET: ServicePrices/Edit/5
        public async Task<IActionResult> Edit(ServicePriceViewModel servicePriceViewModel, string returnController, string returnAction, string returnId)
        {
            servicePriceViewModel.ServicePrice = await _servicePriceRepository.GetById(new GetServicePriceById(servicePriceViewModel.Id));
            servicePriceViewModel.ReturnController = returnController;
            servicePriceViewModel.ReturnId = returnAction;
            servicePriceViewModel.ReturnId = returnId;
            
            return servicePriceViewModel.ServicePrice == new ServicePrice() ? NotFound() : View(servicePriceViewModel);
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
                ServicePrice updatedStudent = await _servicePriceRepository.Update(new GetServicePriceById(id), servicePriceViewModel);
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
        public async Task<IActionResult> Delete(ServicePriceViewModel servicePriceViewModel, string returnController, string returnAction, string returnId)
        {
            servicePriceViewModel.ServicePrice = await _servicePriceRepository.GetById(new GetServicePriceById(servicePriceViewModel.Id));


            servicePriceViewModel.ReturnController = returnController;
            servicePriceViewModel.ReturnAction = returnAction;
            servicePriceViewModel.ReturnId = returnId;
            

            return servicePriceViewModel.Id == 0 ? NotFound() : View(servicePriceViewModel);
        }

        // POST: ServicePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ServicePriceViewModel viewModel, string returnController = "", string returnAction = "", string returnId = "")
        {
            await _servicePriceRepository.Delete(new GetServicePriceById(viewModel.Id));

            if (returnController != "")
                viewModel.ReturnController = returnController;
            if (returnAction != "")
                viewModel.ReturnAction = returnAction;
            if (returnId != "")
                viewModel.ReturnId = returnId;


            return viewModel.ReturnAction == null ? RedirectToAction(nameof(Index)) : (IActionResult)RedirectToAction(viewModel.ReturnAction, viewModel.ReturnController, viewModel.ReturnId);
        }
    }
}
