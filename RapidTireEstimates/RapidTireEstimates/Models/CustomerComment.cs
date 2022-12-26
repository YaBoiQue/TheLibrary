using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class CustomerComment : Comment
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}