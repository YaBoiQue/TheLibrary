using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimatePrice : Price
    {
        public ServiceEstimatePrice()
        {
            ServiceEstimate = new ServiceEstimate();
        }

        [ForeignKey("ServiceEstimate")]
        public int ServiceEstimateId { get; set; }

        [Display(Name = "Comment")]
        public string? Comment { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }
    }
}
