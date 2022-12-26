using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class PurchasedPart : Part
    {
        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Profit Margin")]
        public int UpsalePercent { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}