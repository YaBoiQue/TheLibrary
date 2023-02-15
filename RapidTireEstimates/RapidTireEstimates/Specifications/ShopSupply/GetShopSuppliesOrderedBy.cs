using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetShopSuppliesOrderedBy : Specification<ShopSupply>
    {
        public GetShopSuppliesOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.NameDESC:
                    _ = Query.OrderByDescending(o => o.Name).ThenByDescending(o => o.Value);
                    break;
                case SortByParameter.ValueDESC:
                    _ = Query.OrderByDescending(o => o.Value).ThenByDescending(o => o.Name);
                    break;
                case SortByParameter.ValueASC:
                    _ = Query.OrderBy(o => o.Value).ThenBy(o => o.Name);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Name).ThenBy(o => o.Value);
                    break;
            }
        }
    }
}
