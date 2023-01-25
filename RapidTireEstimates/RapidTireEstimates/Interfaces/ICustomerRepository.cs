using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        public Task<List<Customer>> GetCustomers(ISpecification<Customer> filterBySpec, ISpecification<Customer> orderBySpec);
        public Task<Customer> GetCustomerById(ISpecification<Customer> byIdSpec);
        public Task<Customer> GetCustomerByEstimateId(ISpecification<Customer> estimateIdSpec);
        public Task<Customer> GetCustomerByVehicleId(ISpecification<Customer> vehicleIdSpec);
        public Task<Customer> GetCustomerByCommentId(ISpecification<Customer> commentIdSpec);
        public Task<Customer> InsertCustomer(CustomerViewModel customerViewModel);
        public Task<Customer> UpdateCustomer(ISpecification<Customer> byIdSpec, CustomerViewModel customerViewModel);
        public Task DeleteCustomer(ISpecification<Customer> byIdSpec);
    }
}
