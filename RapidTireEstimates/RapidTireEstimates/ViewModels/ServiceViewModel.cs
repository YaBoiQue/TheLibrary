using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RapidTireEstimates.Helpers;
using RapidTireEstimates.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.ViewModels
{
    public class ServiceViewModel
    {
        public ServiceViewModel()
        {
            Prices = new List<ServicePrice>();
            VehicleTypes = new List<VehicleType>();
            ServiceEstimates = new List<ServiceEstimate>();
            Services = new List<Service>();
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

            Prices = new List<ServicePrice>();
            VehicleTypes = new List<VehicleType>();
            VehicleTypesId = new List<int>();
            ServiceEstimates = new List<ServiceEstimate>();
            Services = new List<Service>();
        }

        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Hours { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }

        public ServicePrice? ServicePrice { get; set; }

        public IEnumerable<ServicePrice>? Prices { get; set; }
        public IEnumerable<VehicleType>? VehicleTypes { get; set; }
        public IEnumerable<int>? VehicleTypesId { get; set; }
        public IEnumerable<ServiceEstimate>? ServiceEstimates { get; set; }

        public IEnumerable<Service> Services { get; set; }
        [Display(Name = "Vehicle Types")]
        public List<VehicleType>? AllVehicleTypes { get; set; }
        public List<SelectListItem>? VehicleTypeSelectList { get; set; }

        public string? ReturnController { get; set; }
        public string? ReturnAction { get; set; }
        public string? ReturnId { get; set; }

        public string? FilterBy { get; internal set; }
        public Constants.SortByParameter SortBy { get; set; }
        public Constants.SortByParameter SortByName { get; set; }
        public Constants.SortByParameter SortByDescription { get; set; }
    }
}
