using Ardalis.Specification;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Specifications
{
    public class GetVehicleTypesOrderedBy : Specification<VehicleType>
    {
        public GetVehicleTypesOrderedBy(SortByParameter sortBy = 0)
        {

            switch (sortBy)
            {
                case SortByParameter.NameDESC:
                    _ = Query.OrderByDescending(o => o.Name);
                    break;
                default:
                    _ = Query.OrderBy(o => o.Name);
                    break;
            }
        }
    }
}
