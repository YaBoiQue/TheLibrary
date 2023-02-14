using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServicePricesByServiceId : Specification<ServicePrice>
    {
        public GetServicePricesByServiceId(int serviceId)
        {
            _ = Query.Where(p => p.ServiceId == serviceId);
        }
    }
}
