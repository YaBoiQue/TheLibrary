using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RapidTireEstimates.Helpers;
using RapidTireEstimates.Models;
using RapidTireEstimates.Models.Linkers;
using RapidTireEstimates.Specifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class ServiceViewModel : Service
    {
        public ServiceViewModel()
        {
            VehicleTypeIds = new List<int>();
            AllVehicleTypes = new List<VehicleType>();
            VehicleTypeSelectList = new List<SelectListItem>();
            Services = new List<Service>();
            ServicePrice = new ServicePrice();

            ReturnController = "Services";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        public ServiceViewModel(Service service)
        {
            if (service != null)
            {
                Id = service.Id;
                Name = service.Name;
                Description= service.Description;
                Hours = service.Hours;
                Rate = service.Rate;
            }

            VehicleTypeIds = new List<int>();
            AllVehicleTypes = new List<VehicleType>();
            VehicleTypeSelectList = new List<SelectListItem>();
            Services = new List<Service>();
            ServicePrice = new ServicePrice();

            ReturnController = "Services";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        //Storage Variables
        public Service Service { get; set; }
        public ServicePrice ServicePrice { get; set; }
        public IEnumerable<Service> Services { get; set; }

        //Vehicle Type Values (for vehicle type selection feature)
        [Display(Name = "Vehicle Types")]
        public List<VehicleType> AllVehicleTypes { get; set; }
        public IEnumerable<int> VehicleTypeIds { get; set; }
        public List<SelectListItem> VehicleTypeSelectList { get; set; }

        //Return Address Values (for dynamic return feature)
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        //Filter/Sort Values (for filter/sort feature)
        public string FilterBy { get; internal set; }
        public Constants.SortByParameter SortBy { get; set; }
        public Constants.SortByParameter SortByName { get; set; }
        public Constants.SortByParameter SortByDescription { get; set; }
    }
}
