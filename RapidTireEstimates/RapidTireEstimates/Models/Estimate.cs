using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class Estimate
    {
        public Estimate()
        {
            DateCreated = DateTime.Now;
            Customer = new Customer();
            Vehicle = new Vehicle();

            Services = new List<ServiceEstimate>();
            Comments = new List<EstimateComment>();
            ShopSupplies = new List<EstimateShopSupply>();
            PurchasedParts = new List<PurchasedPart>();
        }

        public Estimate(Estimate estimate)
        {
            DateCreated = null;

            if (estimate != null)
            {
                Id = estimate.Id;
                CustomerId = estimate.CustomerId;
                VehicleId = estimate.VehicleId;
                DateCreated = estimate.DateCreated;
                DateFinished = estimate.DateFinished;
                ShopToolAmount = estimate.ShopToolAmount;
                FinalPrice = estimate.FinalPrice;
                Customer = estimate.Customer;
                Vehicle = estimate.Vehicle;
                Services = estimate.Services;
                Comments = estimate.Comments;
                ShopSupplies = estimate.ShopSupplies;
                PurchasedParts = estimate.PurchasedParts;
            }

            DateCreated ??= DateTime.Now;
            Customer ??= new Customer();
            Vehicle ??= new Vehicle();

            Services ??= new List<ServiceEstimate>();
            Comments ??= new List<EstimateComment>();
            ShopSupplies ??= new List<EstimateShopSupply>();
            PurchasedParts ??= new List<PurchasedPart>();
        }

        public Estimate(EstimateViewModel estimateViewModel)
        {
            if (estimateViewModel != null)
            {
                Id = estimateViewModel.Id;
                CustomerId = estimateViewModel.CustomerId;
                VehicleId = estimateViewModel.VehicleId;
                DateCreated = estimateViewModel.DateCreated;
                DateFinished = estimateViewModel.DateFinished;
                ShopToolAmount = estimateViewModel.ShopToolAmount;
                FinalPrice = estimateViewModel.FinalPrice;
                Customer = estimateViewModel.Customer;
                Vehicle = estimateViewModel.Vehicle;
                Services = estimateViewModel.Services;
                Comments = estimateViewModel.Comments;
                ShopSupplies = estimateViewModel.ShopSupplies;
                PurchasedParts = estimateViewModel.PurchasedParts;
            }

            DateCreated ??= DateTime.Now;
            Customer ??= new Customer();
            Vehicle ??= new Vehicle();

            Services ??= new List<ServiceEstimate>();
            Comments ??= new List<EstimateComment>();
            ShopSupplies ??= new List<EstimateShopSupply>();
            PurchasedParts ??= new List<PurchasedPart>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime? DateCreated { get; set; }
        [Display(Name = "Completion Date")]
        public DateTime DateFinished { get; set; }
        [Display(Name = "Shop Tool Use")]
        [Column(TypeName = "percentage")]
        public decimal ShopToolAmount { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Final Price")]
        [Column(TypeName = "money")]
        public decimal FinalPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public IEnumerable<ServiceEstimate> Services { get; set; }
        public IEnumerable<EstimateComment> Comments { get; set; }
        public IEnumerable<EstimateShopSupply> ShopSupplies { get; set; }
        public IEnumerable<PurchasedPart> PurchasedParts { get; set; }
    }
}
