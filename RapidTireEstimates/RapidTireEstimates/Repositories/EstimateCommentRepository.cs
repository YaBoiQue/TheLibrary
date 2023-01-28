using Ardalis.Specification;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class EstimateCommentRepository : IEstimateCommentRepository
    {
        private bool disposedValue;

        public Task Delete(ISpecification<EstimateComment> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<EstimateComment>> GetAll(ISpecification<EstimateComment> filterBySpec, ISpecification<EstimateComment> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<EstimateComment> GetByEstimateId(ISpecification<EstimateComment> byEstimateIdSpec, ISpecification<EstimateComment> filterBySpec, ISpecification<EstimateComment> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<EstimateComment> GetById(ISpecification<EstimateComment> byIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<EstimateComment> Insert(EstimateCommentViewModel estimateCommentViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<EstimateComment> Update(ISpecification<EstimateComment> byIdSpec, EstimateCommentViewModel estimateCommentViewModel)
        {
            throw new NotImplementedException();
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
