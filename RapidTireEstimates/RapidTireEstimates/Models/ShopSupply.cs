using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ShopSupply : Part
    {
        public ShopSupply()
        {
            Estimates = new List<EstimateShopSupply>();
        }

        public IEnumerable<EstimateShopSupply> Estimates { get; set; }
    }
}