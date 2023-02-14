using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServiceEstimatePriceByServiceEstimateId : Specification<ServiceEstimatePrice>
    {
        public GetServiceEstimatePriceByServiceEstimateId(int serviceEstimateId)
        {
            _ = Query.Where(s => s.ServiceEstimateId == serviceEstimateId);
        }
    }
}
