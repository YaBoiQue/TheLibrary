using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetServicesOrderedBy : Specification<Service>
    {
        public GetServicesOrderedBy(SortByParameter sortBy)
        {
            switch (sortBy)
            {
                case SortByParameter.NameDESC:
                    _ = Query.OrderByDescending(o => o.Name).ThenByDescending(o => o.Number);
                    break;
                case SortByParameter.DescrDESC:
                    _ = Query.OrderByDescending(o => o.Description).ThenByDescending(o => o.Name);
                    break;
                case SortByParameter.DescrASC:
                    _ = Query.OrderBy(o => o.Description).ThenBy(o => o.Name);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Name).ThenBy(o => o.Number);
                    break;
            }
        }
    }
}
