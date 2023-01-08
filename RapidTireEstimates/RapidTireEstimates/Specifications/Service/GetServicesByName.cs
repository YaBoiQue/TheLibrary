using Ardalis.Specification;
using RapidTireEstimates.Models;

namespace RapidTireEstimates.Specifications
{
    public class GetServicesByName : Specification<Service>
    {
        public GetServicesByName(string name)
        {
            _ = Query.Where(s => s.Name == name);
        }
    }
}
