using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class EstimateCommentRepository : IEstimateCommentRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public EstimateCommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<EstimateComment> byIdSpec)
        {
            var estimateComment = await _context.EstimateComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (estimateComment == null)
                return;

            _ = _context.Remove(estimateComment);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<EstimateComment>> GetAll(ISpecification<EstimateComment> filterBySpec, ISpecification<EstimateComment> orderBySpec)
        {
            return await _context.EstimateComment.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<EstimateComment>> GetByEstimateId(ISpecification<EstimateComment> byEstimateIdSpec, ISpecification<EstimateComment> filterBySpec, ISpecification<EstimateComment> orderBySpec)
        {
            return await _context.EstimateComment.WithSpecification(byEstimateIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<EstimateComment> GetById(ISpecification<EstimateComment> byIdSpec)
        {
            var estimateComment = await _context.EstimateComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            estimateComment ??= new EstimateComment();

            return estimateComment;
        }

        public async Task<EstimateComment> Insert(EstimateCommentViewModel estimateCommentViewModel)
        {
            if (estimateCommentViewModel == null)
            {
                return new EstimateComment();
            }

            var estimateComment = new EstimateComment() { EstimateId = estimateCommentViewModel.EstimateId, Contents = estimateCommentViewModel.Contents };

            var estimate = await _context.Estimate.Where(e => e.Id == estimateComment.EstimateId).SingleOrDefaultAsync();
            
            if (estimate == null)
            {
                return new EstimateComment();
            }

            estimateComment.Estimate = estimate;

            _ = _context.Add(estimate);
            _ = await _context.SaveChangesAsync();

            return estimateComment;
        }

        public async Task<EstimateComment> Update(ISpecification<EstimateComment> byIdSpec, EstimateCommentViewModel estimateCommentViewModel)
        {
            var estimateComment = await _context.EstimateComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (estimateComment == null)
                return new EstimateComment();

            estimateComment.Contents = estimateCommentViewModel.Contents;

            _ = _context.Update(estimateComment);
            _ = await _context.SaveChangesAsync();

            return estimateComment;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~EstimateCommentRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
