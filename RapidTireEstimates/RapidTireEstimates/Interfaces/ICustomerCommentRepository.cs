using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface ICustomerCommentRepository : IDisposable
    {
        public Task<List<CustomerComment>> GetAll(
            ISpecification<CustomerComment> filterBySpec,
            ISpecification<CustomerComment> orderBySpec
            );
        public Task<CustomerComment> GetById(
            ISpecification<CustomerComment> byIdSpec
            );
        public Task<List<CustomerComment>> GetByCustomerId(
            ISpecification<CustomerComment> byCustomerIdSpec,
            ISpecification<CustomerComment> filterBySpec,
            ISpecification<CustomerComment> orderBySpec
            );
        public Task<CustomerComment> Insert(
            CustomerCommentViewModel customerCommentViewModel
            );
        public Task<CustomerComment> Update(
            ISpecification<CustomerComment> byIdSpec,
            CustomerCommentViewModel customerCommentViewModel
            );
        public Task Delete(
            ISpecification<CustomerComment> byIdSpec
            );

    }
}
