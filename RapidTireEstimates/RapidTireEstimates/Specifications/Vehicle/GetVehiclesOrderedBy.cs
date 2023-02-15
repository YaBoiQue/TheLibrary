using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetVehiclesOrderedBy : Specification<Vehicle>
    {
        public GetVehiclesOrderedBy(SortByParameter sortBy)
        {

            switch (sortBy)
            {
                case SortByParameter.MakeDESC:
                    _ = Query.OrderByDescending(o => o.Make).ThenByDescending(o => o.Model).ThenByDescending(o => o.Year);
                    break;
                case SortByParameter.ModelDESC:
                    _ = Query.OrderByDescending(o => o.Model).ThenByDescending(o => o.Make).ThenByDescending(o => o.Year);
                    break;
                case SortByParameter.ModelASC:
                    _ = Query.OrderBy(o => o.Model).ThenBy(o => o.Make).ThenBy(o => o.Year);
                    break;
                case SortByParameter.YearDESC:
                    _ = Query.OrderByDescending(o => o.Year).ThenByDescending(o => o.Make).ThenByDescending(o => o.Model);
                    break;
                case SortByParameter.YearASC:
                    _ = Query.OrderBy(o => o.Year).ThenBy(o => o.Make).ThenBy(o => o.Model);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Make).ThenBy(o => o.Model).ThenBy(o => o.Year);
                    break;
            }
        }
    }
}
