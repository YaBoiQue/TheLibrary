using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ServiceEstimateCommentRepository : IServiceEstimateCommentRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public ServiceEstimateCommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<ServiceEstimateComment> byIdSpec)
        {
            var comment = await _context.ServiceEstimateComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (comment == null)
                return;

            _ = _context.Remove(comment);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<ServiceEstimateComment>> GetAll(ISpecification<ServiceEstimateComment> filterBySpec, ISpecification<ServiceEstimateComment> orderBySpec)
        {
            return await _context.ServiceEstimateComment.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ServiceEstimateComment> GetById(ISpecification<ServiceEstimateComment> byIdSpec)
        {
            var comment = await _context.ServiceEstimateComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (comment == null)
                return new ServiceEstimateComment();

            return comment;
        }

        public async Task<List<ServiceEstimateComment>> GetByServiceEstimateId(ISpecification<ServiceEstimateComment> byServiceEstimateIdSpec, ISpecification<ServiceEstimateComment> filterBySpec, ISpecification<ServiceEstimateComment> orderBySpec)
        {
            return await _context.ServiceEstimateComment.WithSpecification(byServiceEstimateIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ServiceEstimateComment> Insert(ServiceEstimateCommentViewModel serviceEstimateCommentViewModel)
        {
            if (serviceEstimateCommentViewModel == null)
                return new ServiceEstimateComment();

            var serviceEstimateComment = new ServiceEstimateComment(serviceEstimateCommentViewModel);

            _ = _context.Add(serviceEstimateComment);
            _ = await _context.SaveChangesAsync();

            return serviceEstimateComment;
        }

        public async Task<ServiceEstimateComment> Update(ISpecification<ServiceEstimateComment> byIdSpec, ServiceEstimateCommentViewModel serviceEstimateCommentViewModel)
        {
            var serviceEstimateComment = await _context.ServiceEstimateComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (serviceEstimateComment == null || serviceEstimateCommentViewModel == null)
                return new ServiceEstimateComment();

            serviceEstimateComment.Contents = serviceEstimateCommentViewModel.Contents;
            serviceEstimateComment.DateCreated = DateTime.Now;

            _ = _context.Update(serviceEstimateComment);
            _ = await _context.SaveChangesAsync();

            return serviceEstimateComment;
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
        // ~ServiceEstimateCommentRepository()
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
