using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Vehicle Type")]
        public string? Name { get; set; }

        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Service>? Services { get; set; }

        public VehicleType() { }
        public VehicleType(string Name)
        {
            this.Name = Name;
        }
    }
}