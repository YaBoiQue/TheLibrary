using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;
using System.Runtime.CompilerServices;

namespace RapidTireEstimates.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        public Task<List<Customer>> GetAll(
            ISpecification<Customer> filterBySpec, 
            ISpecification<Customer> orderBySpec
            );
        public Task<Customer> GetById(
            ISpecification<Customer> byIdSpec
            );
        public Task<Customer> GetByEstimateId(
            ISpecification<Customer> estimateIdSpec
            );
        public Task<Customer> GetByVehicleId(
            ISpecification<Customer> vehicleIdSpec
            );
        public Task<Customer> GetByCommentId(
            ISpecification<Customer> commentIdSpec
            );
        public Task<Customer> Insert(
            CustomerViewModel customerViewModel
            );
        public Task<Customer> Update(
            ISpecification<Customer> byIdSpec, 
            CustomerViewModel customerViewModel
            );
        public Task Delete(
            ISpecification<Customer> byIdSpec
            );
    }
}
