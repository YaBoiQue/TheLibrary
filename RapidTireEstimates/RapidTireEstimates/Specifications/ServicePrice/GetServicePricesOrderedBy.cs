using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetServicePricesOrderedBy : Specification<ServicePrice>
    {
        public GetServicePricesOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.ValueDESC: // "first_name_desc":
                    _ = Query.OrderByDescending(o => o.Value).ThenByDescending(o => o.Level);
                    break;
                case SortByParameter.ValueASC: // "last_name_asc":
                    _ = Query.OrderBy(o => o.Value).ThenBy(o => o.Level);
                    break;
                case SortByParameter.LevelDESC: // "last_name_desc":
                    _ = Query.OrderByDescending(o => o.Level).ThenByDescending(o => o.Value);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Level).ThenBy(o => o.Value);
                    break;
            }
        }


    }
}
