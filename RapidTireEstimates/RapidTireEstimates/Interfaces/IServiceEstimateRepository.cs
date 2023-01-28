using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServiceEstimateRepository : IDisposable
    {
        public Task<List<ServiceEstimate>> GetAll(
            ISpecification<ServiceEstimate> filterBySpec,
            ISpecification<ServiceEstimate> orderBySpec
            );
        public Task<List<ServiceEstimate>> GetByEstimateId(
            ISpecification<ServiceEstimate> byEstimateIdSpec,
            ISpecification<ServiceEstimate> filterBySpec,
            ISpecification<ServiceEstimate> orderBySpec
            );
        public Task<List<ServiceEstimate>> GetByServiceId(
            ISpecification<ServiceEstimate> byServiceIdSpec,
            ISpecification<ServiceEstimate> filterBySpec,
            ISpecification<ServiceEstimate> orderBySpec
            );
        public Task<ServiceEstimate> GetById(
            ISpecification<ServiceEstimate> byIdSpec
            );
        public Task<ServiceEstimate> GetByCommentId(
            ISpecification<ServiceEstimate> byCommentIdSpec
            );
        public Task<ServiceEstimate> GetByPriceId(
            ISpecification<ServiceEstimate> byPriceIdSpec
            );
        public Task<ServiceEstimate> Insert(
            ServiceEstimateViewModel serviceEstimateViewModel
            );
        public Task<ServiceEstimate> Update(
            ISpecification<ServiceEstimate> byIdSpec,
            ServiceEstimateViewModel serviceEstimateViewModel
            );
        public Task<ServiceEstimate> Delete(
            ISpecification<ServiceEstimate> byIdSpec
            );
    }
}
