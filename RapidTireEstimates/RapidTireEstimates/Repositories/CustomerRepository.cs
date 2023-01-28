using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private bool disposedValue;
        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<Customer> byIdSpec)
        {
            Customer? customer = await _context.Customer.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (customer == null)
            {
                return;
            }

            _ = _context.Customer.Remove(customer);

            _ = await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetByCommentId(ISpecification<Customer> commentIdSpec)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByEstimateId(ISpecification<Customer> estimateIdSpec)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetById(ISpecification<Customer> byIdSpec)
        {
            if (byIdSpec == null)
            {
                return new Customer();
            }
            var customer = await _context.Customer.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if(customer == null)
            {
                return new Customer();
            }
            return customer;
        }

        public Task<Customer> GetByVehicleId(ISpecification<Customer> vehicleIdSpec)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAll(ISpecification<Customer> filterBySpec, ISpecification<Customer> orderBySpec)
        {
            return await _context.Customer.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<Customer> Insert(CustomerViewModel customerViewModel)
        {
            Customer customer = new Customer();

            customer.Name = customerViewModel.Name;
            customer.PhoneNumber = customerViewModel.PhoneNumber;

            _ = _context.Add(customer);
            _ = await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Update(ISpecification<Customer> byIdSpec, CustomerViewModel customerViewModel)
        {
            Customer? customer = new Customer();


            try
            {
                customer = await _context.Customer.WithSpecification(byIdSpec).SingleOrDefaultAsync();

                if (customer == null)
                    return new Customer();

                customer.Name = customerViewModel.Name;
                customer.PhoneNumber = customerViewModel.PhoneNumber;

                _ = _context.Update(customer);
                _ = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customerViewModel.Id))
                {
                    return new Customer();
                }
                else
                {
                    throw;
                }
            }

            return customer;
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
        // ~CustomerRepository()
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

        
        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
