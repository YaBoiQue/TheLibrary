using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServicePrice : Price
    {
        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Display(Name = "Pricing Description")]
        public string? Description { get; set; }
        [Display(Name = "Pricing Level")]
        public Int16 Level { get; set; }

        public virtual Service Service { get; set; }
    }
}
