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

        public async Task<List<CustomerComment>> GetAll(ISpecification<CustomerComment> filterBySpec, ISpecification<CustomerComment> orderBySpec)
        {
            return await _context.CustomerComment.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<CustomerComment>> GetByCustomerId(ISpecification<CustomerComment> byCustomerIdSpec, ISpecification<CustomerComment> filterBySpec, ISpecification<CustomerComment> orderBySpec)
        {
            return await _context.CustomerComment.WithSpecification(byCustomerIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<CustomerComment> GetById(ISpecification<CustomerComment> byIdSpec)
        {
            if (byIdSpec == null)
                return new CustomerComment();

            var customerComment = await _context.CustomerComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            customerComment ??= new CustomerComment();

            return customerComment;
        }

        public async Task<CustomerComment> Insert(CustomerCommentViewModel customerCommentViewModel)
        {
            if (customerCommentViewModel == null)
            {
                return new CustomerComment();
            }

            var customerComment = new CustomerComment() { CustomerId = customerCommentViewModel.CustomerId, DateCreated = customerCommentViewModel.DateCreated, Contents = customerCommentViewModel.Contents };

            var customer = _context.Customer.Where(c => c.Id == customerComment.CustomerId).FirstOrDefault();

            if (customer == null)
            {
                return new CustomerComment();
            }

            customerComment.Customer = customer;

            _ = _context.Add(customerComment);
            _ = await _context.SaveChangesAsync();

            return customerComment;
        }

        public async Task<CustomerComment> Update(ISpecification<CustomerComment> byIdSpec, CustomerCommentViewModel customerCommentViewModel)
        {
            CustomerComment? customerComment;

            customerComment = await _context.CustomerComment.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (customerComment == null)
                return new CustomerComment();

            customerComment.Contents = customerCommentViewModel.Contents;

            _ = _context.Update(customerComment);
            _ = await _context.SaveChangesAsync();

            return customerComment;
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
