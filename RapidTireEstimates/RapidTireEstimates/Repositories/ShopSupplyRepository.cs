using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.ViewModels;

namespace RapidTireEstimates.Repositories
{
    public class ShopSupplyRepository : IShopSupplyRepository
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public ShopSupplyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ISpecification<ShopSupply> byIdSpec)
        {
            var supply = await _context.ShopSupply.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (supply == new ShopSupply()||supply == null)
                return;

            _ = _context.Remove(supply);
            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<ShopSupply>> GetAll(ISpecification<ShopSupply> filterBySpec, ISpecification<ShopSupply> orderBySpec)
        {
            return await _context.ShopSupply.WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<List<ShopSupply>> GetByEstimateId(ISpecification<ShopSupply> byEstimateIdSpec, ISpecification<ShopSupply> filterBySpec, ISpecification<ShopSupply> orderBySpec)
        {
            return await _context.ShopSupply.WithSpecification(byEstimateIdSpec).WithSpecification(filterBySpec).WithSpecification(orderBySpec).ToListAsync();
        }

        public async Task<ShopSupply> GetById(ISpecification<ShopSupply> byIdSpec)
        {
            var supply = await _context.ShopSupply.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            supply ??= new ShopSupply();
            return supply;
        }

        public async Task<ShopSupply> Insert(ShopSupplyViewModel shopSupplyViewModel)
        {
            if (shopSupplyViewModel == null)
                return new ShopSupply();

            _ = _context.Add(shopSupplyViewModel.ShopSupply);
            _ = await _context.SaveChangesAsync();

            return shopSupplyViewModel.ShopSupply;
        }

        public async Task<ShopSupply> Update(ISpecification<ShopSupply> byIdSpec, ShopSupplyViewModel shopSupplyViewModel)
        {
            var supply = await _context.ShopSupply.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (supply == null || shopSupplyViewModel == null)
                return new ShopSupply();

            if (supply.Id == shopSupplyViewModel.ShopSupply.Id)
                return new ShopSupply();

            supply = shopSupplyViewModel.ShopSupply;

            _ = _context.Update(supply);
            _ = await _context.SaveChangesAsync();

            return supply;
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
        // ~ShopSupplyRepository()
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
