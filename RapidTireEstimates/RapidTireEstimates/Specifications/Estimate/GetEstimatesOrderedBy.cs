using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetEstimatesOrderedBy : Specification<Estimate>
    {
        public GetEstimatesOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.DateDESC:
                    _ = Query.OrderByDescending(o => o.DateCreated).ThenByDescending(o => o.FinalPrice);
                    break;
                case SortByParameter.PriceDESC:
                    _ = Query.OrderByDescending(o => o.FinalPrice).ThenByDescending(o => o.DateCreated);
                    break;
                case SortByParameter.PriceASC:
                    _ = Query.OrderBy(o => o.FinalPrice).ThenBy(o => o.DateCreated);
                    break;
                default:
                    _ = Query.OrderBy(o => o.DateCreated).ThenBy(o => o.FinalPrice);
                    break;
            }
        }
    }
}
