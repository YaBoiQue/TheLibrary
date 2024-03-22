namespace TheWarehouse.Repositories
{
    public class SupplierRepository(ApplicationDbContext context) : ISuppliers
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Supplier?> Create(Supplier obj)
        {
            _context.Suppliers.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Supplier?> Delete(ISpecification<Supplier> objId)
        {
            Supplier? supplier = await _context.Suppliers.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supplier) return new();

            _context.Suppliers.Remove(supplier);

            await _context.SaveChangesAsync();

            return supplier;
        }

        public async Task<Supplier?> GetById(ISpecification<Supplier> objId)
        {
            if (null == objId)
                return new();

            Supplier? supplier = await _context.Suppliers.WithSpecification(objId).SingleOrDefaultAsync();

            supplier ??= new();

            return supplier;
        }

        public async Task<Supplier?> GetBySupply(ISpecification<Supply> objId)
        {
            Supply? supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supply) return new();

            Supplier? supplier = await _context.Suppliers.Where(c => c.SupplierId == supply.SupplierId).SingleOrDefaultAsync();

            if (null == supplier) return new();

            return supplier;
        }

        public async Task<Supplier?> Save(ISpecification<Supplier> objId, Supplier obj)
        {
            Supplier? supplier = new();

            try
            {
                supplier = await _context.Suppliers.WithSpecification(objId).SingleOrDefaultAsync();

                if (supplier == null)
                    return supplier;

                supplier = obj;

                _context.Update(supplier);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (supplier == null) return new();
                if (!_context.Suppliers.Any(c => c.SupplierId == supplier.SupplierId))
                    return new();
                else throw;
            }

            return supplier;
        }

        public async Task<IEnumerable<Supplier>?> ToList(ISpecification<Supplier> filterBy, ISpecification<Supplier> orderBy)
        {
            return await _context.Suppliers.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~SupplierRepository()
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
