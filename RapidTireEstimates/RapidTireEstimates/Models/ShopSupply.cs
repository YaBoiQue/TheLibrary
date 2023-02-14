using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class ShopSupply : Part
    {
        public ShopSupply()
        {
            Estimates = new List<EstimateShopSupply>();
        }
        
        public ShopSupply(ShopSupplyViewModel shopSupplyViewModel)
        {
            if (shopSupplyViewModel != null)
            {
                Id = shopSupplyViewModel.Id;
                Value = shopSupplyViewModel.Value;
                Name = shopSupplyViewModel.Name;
                Description = shopSupplyViewModel.Description;
                Estimates = shopSupplyViewModel.Estimates;
            }
            Estimates ??= new List<EstimateShopSupply>();
        }

        public IEnumerable<EstimateShopSupply> Estimates { get; set; }
    }
}