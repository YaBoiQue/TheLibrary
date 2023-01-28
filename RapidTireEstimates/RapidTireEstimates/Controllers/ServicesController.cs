using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public ServicesController(IServiceRepository serviceRepository, IVehicleTypeRepository vehicleTypeRepository)
        {
            _serviceRepository = serviceRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        // GET: Services
        public async Task<IActionResult> Index(ServiceViewModel serviceViewModel)
        {
            serviceViewModel.SortByName = (serviceViewModel.SortBy == SortByParameter.NameASC) 
                ? SortByParameter.NameDESC : Helpers.Constants.SortByParameter.NameASC;
            serviceViewModel.SortByDescription = (serviceViewModel.SortBy == SortByParameter.DescrASC) 
                ? SortByParameter.DescrDESC : SortByParameter.DescrASC;
            serviceViewModel.ReturnController = "Services";
            serviceViewModel.ReturnAction = "Index";
            serviceViewModel.ReturnId = "";
            serviceViewModel.Services = await _serviceRepository.GetAll(
                new GetServicesFilteredBy(serviceViewModel.FilterBy),
                new GetServicesOrderedBy(serviceViewModel.SortBy));

            return View(serviceViewModel);
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var serviceViewModel = new ServiceViewModel(await _serviceRepository.GetById(new GetServiceById((int)id)));
            return serviceViewModel == null ? NotFound() : View(serviceViewModel);
        }

        // GET: Services/Create
        public async Task<IActionResult> Create()
        {
            ServiceViewModel serviceViewModel = new()
            {
                AllVehicleTypes = new List<VehicleType>()
            };
            serviceViewModel.AllVehicleTypes = await _vehicleTypeRepository.GetAll(new GetVehicleTypesFilteredBy(), new GetVehicleTypesOrderedBy());

            serviceViewModel.VehicleTypeSelectList = new List<SelectListItem>();
            foreach (VehicleType item in serviceViewModel.AllVehicleTypes)
            {
                serviceViewModel.VehicleTypeSelectList.Add(new SelectListItem { Text = item.Name.Trim(), Value = item.Id.ToString() });
            }

            return View(serviceViewModel);
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Hours,Rate,VehicleTypeSelectList")] ServiceViewModel serviceViewModel)
        {
            if (serviceViewModel == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceRepository.Insert(serviceViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(serviceViewModel);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service? service = await _serviceRepository.GetById(new GetServiceById((int)id));

            if (service == null)
            {
                return NotFound();
            }

            ServiceViewModel serviceViewModel = new(service);

            return View(serviceViewModel);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,Description,Hours,Rate")] ServiceViewModel serviceViewModel)
        {
            if (id != serviceViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceRepository.Update(new GetServiceById((int)id), serviceViewModel);

                return View(serviceViewModel);
            }

            return View(serviceViewModel);
        }


        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service? service = await _serviceRepository.GetById(new GetServiceById((int)id));
            return service == null ? NotFound() : View(service);
        }


        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceRepository.Delete(new GetServiceById((int)id));

            return RedirectToAction(nameof(Index));
        }
    }
}
