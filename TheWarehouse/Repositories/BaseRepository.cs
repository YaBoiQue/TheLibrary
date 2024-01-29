using Microsoft.EntityFrameworkCore;
using NHibernate.Transform;
using TheWarehouse.Interfaces;

namespace TheWarehouse.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
    {
        private bool disposedValue;
        private readonly WarehouseDbContext _context;

        public BaseRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public void Create(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity obj)
        {
            TEntity? object = await _context.Customer.WithSpecification(byIdSpec).SingleOrDefaultAsync();

            if (customer == null)
            {
                return;
            }

            _ = _context.Customer.Remove(customer);

            _ = await _context.SaveChangesAsync();
        }

        public object GetById(object objId)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> ToList()
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
        // ~BaseRepository()
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
