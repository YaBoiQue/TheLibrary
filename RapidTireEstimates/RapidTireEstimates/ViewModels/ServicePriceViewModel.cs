using Microsoft.AspNetCore.Mvc.Rendering;
using RapidTireEstimates.Helpers;
using RapidTireEstimates.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.ViewModels
{
    public class ServicePriceViewModel
    {
        public ServicePriceViewModel()
        {
            Service = new Service();
            ServicePrices = new List<ServicePrice>();
        }

        public ServicePriceViewModel(ServicePrice servicePrice)
        {
            if (servicePrice != null)
            {
                Id = servicePrice.Id;
                ServiceId = servicePrice.ServiceId;
                Description = servicePrice.Description;
                Level = servicePrice.Level;
                Service = servicePrice.Service;
                Value = servicePrice.Value;
            }
            Service = new Service();
            ServicePrices = new List<ServicePrice>();
        }

        public int Id { get; set; }
        [Required]
        public int ServiceId { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal Value { get; set; }
        [Display(Name = "Pricing Description")]
        public string? Description { get; set; }
        [Display(Name = "Pricing Level")]
        public short Level { get; set; }

        public virtual Service Service { get; set; }
        public List<SelectListItem> Services { get; set; }
        public IEnumerable<ServicePrice> ServicePrices { get; set; }

        public string? FilterBy { get; internal set; }
        public Constants.SortByParameter SortBy { get; set; }
        public Constants.SortByParameter SortByLevel { get; set; }
        public Constants.SortByParameter SortByValue { get; set; }

        public string? ReturnController { get; set; }
        public string? ReturnAction { get; set; }
        public string? ReturnId { get; set; }
    }
}
