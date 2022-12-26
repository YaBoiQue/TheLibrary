using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServiceEstimate
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }

        [Display(Name = "Adjusted Flat-Rate Time")]
        public int AdjustedHours { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual Service Service { get; set; }
        public virtual ServiceEstimatePrice Price { get; set; }
        public ICollection<ServiceEstimateComment>? Comments { get; set; }
    }
}
