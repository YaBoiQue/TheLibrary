using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{ 
    public class GetServiceEstimatePricesOrderedBy : Specification<ServiceEstimatePrice>
    {
        GetServiceEstimatePricesOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.ValueDESC:
                    _ = Query.OrderByDescending(o => o.Value).ThenByDescending(o => o.Comment);
                    break;
                case SortByParameter.ContentsDESC:
                    _ = Query.OrderByDescending(o => o.Comment).ThenByDescending(o => o.Value);
                    break;
                case SortByParameter.ContentsASC:
                    _ = Query.OrderBy(o => o.Comment).ThenBy(o => o.Value);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Value).ThenBy(o => o.Comment);
                    break;
            }
        }
    }
}
