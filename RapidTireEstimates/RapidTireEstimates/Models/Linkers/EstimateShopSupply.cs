using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class EstimateShopSupply
    {
        public EstimateShopSupply()
        {
            Estimate = new Estimate();
            ShopSupply = new ShopSupply();

            DateCreated = DateTime.Now;
        }

        public EstimateShopSupply(int estimateId, int shopSupplyId)
        {
            EstimateId = estimateId;
            ShopSupplyId = shopSupplyId;

            DateCreated = DateTime.Now;

            Estimate = new Estimate();
            ShopSupply = new ShopSupply();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Estimate")]
        public int EstimateId { get; set; }
        [ForeignKey("ShopSupply")]
        public int ShopSupplyId { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Estimate Estimate { get; set; }
        public virtual ShopSupply ShopSupply { get; set; }
    }
}
