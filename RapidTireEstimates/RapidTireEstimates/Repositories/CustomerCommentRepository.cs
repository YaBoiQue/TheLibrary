using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class CustomerCommentRepository : ICustomerCommentRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public CustomerCommentRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<CustomerComment> byIdSpec)
        {
            CustomerComment? customerComment = await _context.CustomerComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (customerComment != null)
            {
                _ = _context.CustomerComment.Remove(customerComment);
            }

            _ = await _context.SaveChangesAsync();
        }

        public Task<List<CustomerComment>> GetAll(ISpecification<CustomerComment> filterBySpec, ISpecification<CustomerComment> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerComment>> GetByCustomerId(ISpecification<CustomerComment> byCustomerIdSpec, ISpecification<CustomerComment> filterBySpec, ISpecification<CustomerComment> orderBySpec)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerComment> GetById(ISpecification<CustomerComment> byIdSpec)
        {
            if (byIdSpec == null)
                return new CustomerComment();

            var customerComment = await _context.CustomerComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            customerComment ??= new CustomerComment();

            return customerComment;
        }

        public Task<CustomerComment> Insert(CustomerCommentViewModel customerCommentViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerComment> Update(ISpecification<CustomerComment> byIdSpec, CustomerCommentViewModel customerCommentViewModel)
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
        // ~CustomerCommentRepository()
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
