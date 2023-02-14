using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimatesByShopSupplyId : Specification<Estimate>
    {
        public GetEstimatesByShopSupplyId(int shopSupplyId)
        {
            _ = Query.Where(e => e.ShopSupplies.Any(s => s.Id == shopSupplyId));
        }
    }
}
