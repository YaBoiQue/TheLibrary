using Ardalis.Specification;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Interfaces
{
    public interface IEstimateCommentRepository : IDisposable
    {
        public Task<List<EstimateComment>> GetAll(
            ISpecification<EstimateComment> filterBySpec,
            ISpecification<EstimateComment> orderBySpec
            );
        public Task<EstimateComment> GetById(
            ISpecification<EstimateComment> byIdSpec
            );
        public Task<List<EstimateComment>> GetByEstimateId(
            ISpecification<EstimateComment> byEstimateIdSpec,
            ISpecification<EstimateComment> filterBySpec,
            ISpecification<EstimateComment> orderBySpec
            );
        public Task<EstimateComment> Insert(
            EstimateCommentViewModel estimateCommentViewModel
            );
        public Task<EstimateComment> Update(
            ISpecification<EstimateComment> byIdSpec,
            EstimateCommentViewModel estimateCommentViewModel
            );
        public Task Delete(
            ISpecification<EstimateComment> byIdSpec
            );
    }
}
