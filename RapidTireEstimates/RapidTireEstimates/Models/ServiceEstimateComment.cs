using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimateComment : Comment
    {
        public ServiceEstimateComment()
        {
            ServiceEstimate = new ServiceEstimate();
        }

        [ForeignKey("ServiceEstimate")]
        public int ServiceEstimateId { get; set; }

        public virtual ServiceEstimate ServiceEstimate { get; set; }
    }
}
