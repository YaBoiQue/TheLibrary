using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatesOrderedBy : Specification<ServiceEstimate>
    {
        public GetServiceEstimatesOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.NameDESC:
                    _ = Query.OrderByDescending(o => o.Service.Name).ThenByDescending(o => o.DateCreated);
                    break;
                case SortByParameter.DateDESC:
                    _ = Query.OrderByDescending(o => o.DateCreated).ThenByDescending(o => o.Service.Name);
                    break;
                case SortByParameter.DateASC:
                    _ = Query.OrderBy(o => o.DateCreated).ThenBy(o => o.Service.Name);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Service.Name).ThenBy(o => o.DateCreated);
                    break;
            }
        }
    }
}
