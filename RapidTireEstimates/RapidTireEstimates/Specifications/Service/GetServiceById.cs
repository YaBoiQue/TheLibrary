using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceById : Specification<Service>
    {
        public GetServiceById(int serviceId)
        {
            _ = Query.Where(s => s.Id == serviceId);
        }
    }
}
