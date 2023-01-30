using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetShopSupplyById : Specification<ShopSupply>
    {
        public GetShopSupplyById(int id)
        {
            _ = Query.Where(s => s.Id == id);
        }
    }
}
