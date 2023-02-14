using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServicesFilteredBy : Specification<Service>
    {
        public GetServicesFilteredBy()
        {
            _ = Query;
        }
        public GetServicesFilteredBy(string filterBy)
        {
            if (!string.IsNullOrEmpty(filterBy))
            {
                _ = Query.Where(s => s.Name == filterBy);
            }
        }
    }
}
