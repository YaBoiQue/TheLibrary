using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimateComment : Comment
    {
        [ForeignKey("ServiceEstimate")]
        public int ServiceEstimateId { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }
    }
}
