using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ServicePrice : Price
    {
        public ServicePrice()
        {
            Description = "";
            Service = new Service();
        }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Display(Name = "Pricing Description")]
        public string Description { get; set; }
        [Display(Name = "Pricing Level")]
        public short Level { get; set; }

        public virtual Service Service { get; set; }
    }
}
