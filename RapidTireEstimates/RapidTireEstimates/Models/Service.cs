using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Service Name")]
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Flat-Rate Time")]
        [Column(TypeName = "decimal(3,2)")]
        public double Hours { get; set; }
        [Display(Name = "Hourly Rate")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }

        public ICollection<ServicePrice>? Prices { get; set; }
        public ICollection<VehicleType> VehicleTypes { get; set; }
        public ICollection<ServiceEstimate>? ServiceEstimates { get; set; }
    }
}
