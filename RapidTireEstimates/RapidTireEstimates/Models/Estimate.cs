using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class Estimate
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime DateCreated { set { DateCreated = DateTime.Now; } }
        [Display(Name = "Completion Date")]
        public DateTime FinishDate { get; set; }
        [Display(Name = "Shop Tool Use")]
        public int ShopTools { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Final Price")]
        [Column(TypeName = "money")]
        public decimal FinalPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public ICollection<ServiceEstimate>? Services { get; set; }
        public ICollection<EstimateComment>? Comments { get; set; }
        public ICollection<ShopSupply>? ShopParts { get; set; }
        public ICollection<PurchasedPart>? PurchasedParts { get; set; }

        public Estimate( )
        {
            this.DateCreated = DateTime.Now;
        }
    }
}
