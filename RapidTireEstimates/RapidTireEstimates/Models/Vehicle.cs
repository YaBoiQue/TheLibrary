using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Make = "";
            Model = "";

            VehicleType = new VehicleType();
            Customer = new Customer();
            Estimates = new List<Estimate>();
            ReplacedParts = new List<PurchasedPart>();
        }

        public Vehicle(VehicleViewModel vehicleViewModel)
        {
            if (vehicleViewModel != null)
            {
                Id = vehicleViewModel.Id;
                CustomerId = vehicleViewModel.CustomerId;
                VehicleTypeId = vehicleViewModel.VehicleTypeId;
                Make = vehicleViewModel.Make;
                Model = vehicleViewModel.Model;
                Year = vehicleViewModel.Year;
                VehicleType = vehicleViewModel.VehicleType;
                Customer = vehicleViewModel.Customer;
                Estimates = vehicleViewModel.Estimates;
                ReplacedParts = vehicleViewModel.ReplacedParts;
            }
            Make ??= "";
            Model ??= "";

            VehicleType ??= new VehicleType();
            Customer ??= new Customer();
            Estimates ??= new List<Estimate>();
            ReplacedParts ??= new List<PurchasedPart>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual Customer Customer { get; set; }
        public IEnumerable<Estimate> Estimates { get; set; }
        public IEnumerable<PurchasedPart> ReplacedParts { get; set; }
    }
}