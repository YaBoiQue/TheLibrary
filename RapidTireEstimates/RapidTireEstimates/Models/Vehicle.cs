using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RapidTireEstimates.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Make { get; set; }
        [Required]
        [StringLength(50)]
        public string? Model { get; set; }
        [Required]
        public int Year { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<Estimate>? Estimates { get; set; }
        public ICollection<PurchasedPart>? ReplacedParts { get; set; }
    }
}