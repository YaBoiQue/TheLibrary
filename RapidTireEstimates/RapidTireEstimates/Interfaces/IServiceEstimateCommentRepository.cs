using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IServiceEstimateCommentRepository : IDisposable
    {
        public Task<List<ServiceEstimateComment>> GetAll(
            ISpecification<ServiceEstimateComment> filterBySpec,
            ISpecification<ServiceEstimateComment> orderBySpec
            );
        public Task<List<ServiceEstimateComment>> GetByServiceEstimateId(
            ISpecification<ServiceEstimateComment> byServiceEstimateIdSpec,
            ISpecification<ServiceEstimateComment> filterBySpec,
            ISpecification<ServiceEstimateComment> orderBySpec
            );
        public Task<ServiceEstimateComment> GetById(
            ISpecification<ServiceEstimateComment> byIdSpec
            );
        public Task<ServiceEstimateComment> Insert(
            ServiceEstimateCommentViewModel serviceEstimateCommentViewModel
            );
        public Task<ServiceEstimateComment> Update(
            ISpecification<ServiceEstimateComment> byIdSpec,
            ServiceEstimateCommentViewModel serviceEstimateCommentViewModel
            );
        public Task Delete(
            ISpecification<ServiceEstimateComment> byIdSpec
            );
    }
}
