using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimatePrice : Price
    {
        [ForeignKey("ServiceEstimate")]
        public int ServiceEstimateId { get; set; }

        [Display(Name = "Pricing Comment")]
        public string? Comment { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }
    }
}
