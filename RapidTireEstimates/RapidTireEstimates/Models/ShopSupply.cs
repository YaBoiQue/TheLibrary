using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ShopSupply : Part
    {
        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }

        public ICollection<Estimate>? Estimates { get; set; }
    }
}