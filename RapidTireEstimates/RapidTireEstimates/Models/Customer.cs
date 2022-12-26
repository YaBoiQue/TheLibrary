using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public ICollection<Estimate>? Estimates { get; set; }
        public ICollection<CustomerComment>? Comments { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}