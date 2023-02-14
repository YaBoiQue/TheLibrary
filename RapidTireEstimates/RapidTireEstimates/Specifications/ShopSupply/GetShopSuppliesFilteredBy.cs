using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetShopSuppliesFilteredBy : Specification<ShopSupply>
    {
        public GetShopSuppliesFilteredBy(string filterBy)
        {
            _ = Query.Where(s => s.Name == filterBy);
        }
    }
}
