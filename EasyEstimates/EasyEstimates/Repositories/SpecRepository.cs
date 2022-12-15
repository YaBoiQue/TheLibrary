using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using EasyEstimates.Data;
using EasyEstimates.Interfaces;
using EasyEstimates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEstimates.Repositories
{
    public class SpecRepository : ISpecRepository
    {
        private bool _disposedValue;
        private EasyEstimatesContext _context;

        public SpecRepository(EasyEstimatesContext context)
        {
            _context = context;
        }

        public async Task<Spec> AddSpec(Spec spec)
        {
            _context.Specs.Add(spec);
            await _context.SaveChangesAsync();

            return spec;
        }

        public async Task<Spec> GetSpec(Specification<Spec> byIdSpec)
        {
            return await _context.Specs.WithSpecification(byIdSpec).SingleOrDefaultAsync();
        }

        public async Task<ICollection<Spec>> GetSpecs()
        {
            return await _context.Specs.ToListAsync();
        }

        public async Task<ICollection<Spec>> GetSpecsByServiceId(Specification<Spec> byServiceIdSpec)
        {
            return await _context.Specs.WithSpecification(byServiceIdSpec).ToListAsync();
        }

        public async Task RemoveSpec(Spec spec)
        {
            _context.Specs.Remove(spec);
            
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SpecRepository()
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
