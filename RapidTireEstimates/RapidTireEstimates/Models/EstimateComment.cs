using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class EstimateComment : Comment
    {
        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }

        public virtual Estimate Estimate { get; set; }
    }
}