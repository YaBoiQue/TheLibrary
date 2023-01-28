using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RapidTireEstimates.Models.Linkers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class Service
    {
        public Service()
        {
            Name = "";
            Description = "";

            Prices = new List<ServicePrice>();
            VehicleTypes = new List<ServiceVehicleType>();
            ServiceEstimates = new List<ServiceEstimate>();
        }

        public Service(Service service)
        {
            Id = service.Id;
            Name = service.Name;
            Description = service.Description;
            Hours = service.Hours;
            Rate = service.Rate;
            Number = service.Number;
            Prices = service.Prices;
            VehicleTypes = service.VehicleTypes;
            ServiceEstimates = service.ServiceEstimates;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Flat-Rate Time")]
        [Column(TypeName = "decimal(3,2)")]
        public decimal Hours { get; set; }
        [Required]
        [Display(Name = "Hourly Rate")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }

        public int Number { get; set; }

        public IEnumerable<ServicePrice> Prices { get; set; }
        public IEnumerable<ServiceVehicleType> VehicleTypes { get; set; }
        public IEnumerable<ServiceEstimate> ServiceEstimates { get; set; }


    }
}
