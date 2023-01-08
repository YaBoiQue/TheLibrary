using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServicePriceById : Specification<ServicePrice>
    {
        public GetServicePriceById(int priceId)
        {
            _ = Query.Where(p => p.Id == priceId);
        }

    }
}
