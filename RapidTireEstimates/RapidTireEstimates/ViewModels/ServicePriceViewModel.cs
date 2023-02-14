using Microsoft.AspNetCore.Mvc.Rendering;
using RapidTireEstimates.Helpers;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.ViewModels
{
    public class ServicePriceViewModel : ServicePrice
    {
        public ServicePriceViewModel()
        {
            ServicePrice = new ServicePrice();

            Services = new List<SelectListItem>();
            ServicePrices = new List<ServicePrice>();

            ReturnController = "ServicePrices";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
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
            ServicePrice = new ServicePrice();

            Services = new List<SelectListItem>();
            ServicePrices = new List<ServicePrice>();

            ReturnController = "ServicePrices";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        //Storage Variables
        public ServicePrice ServicePrice { get; set; }

        //Lists
        public List<SelectListItem> Services { get; set; }
        public IEnumerable<ServicePrice> ServicePrices { get; set; }

        //Return values(for address return feature)
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        //Filter/Sort values(for filter/sort feature)
        public string FilterBy { get; set; }
        public Constants.SortByParameter SortBy { get; set; }
        public Constants.SortByParameter SortByLevel { get; set; }
        public Constants.SortByParameter SortByValue { get; set; }
    }
}
