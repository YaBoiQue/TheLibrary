using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServicePrice : Price
    {
        public ServicePrice()
        {
            Description = "";
            Service = new Service();
        }

        public ServicePrice(ServicePriceViewModel servicePriceViewModel)
        {
            if (servicePriceViewModel != null)
            {
                Id = servicePriceViewModel.Id;
                Value = servicePriceViewModel.Value;
                ServiceId = servicePriceViewModel.ServiceId;
                Description = servicePriceViewModel.Description;
                Level = servicePriceViewModel.Level;
                Service = servicePriceViewModel.Service;
            }
            Description ??= "";
            Service ??= new Service();
        }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Display(Name = "Pricing Description")]
        public string Description { get; set; }
        [Display(Name = "Pricing Level")]
        public short Level { get; set; }

        public virtual Service Service { get; set; }
    }
}
