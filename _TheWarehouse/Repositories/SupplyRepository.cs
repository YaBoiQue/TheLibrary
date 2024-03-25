namespace TheWarehouse.Repositories
{
    public class SupplyRepository(ApplicationDbContext context) : ISupplies
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Supply?> Create(Supply obj)
        {
            _context.Supplies.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Supply?> Delete(ISpecification<Supply> objId)
        {
            Supply? supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supply) return new();

            _context.Supplies.Remove(supply);

            await _context.SaveChangesAsync();

            return supply;
        }

        public async Task<Supply?> GetById(ISpecification<Supply> objId)
        {
            if (null == objId)
                return new();

            Supply? supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

            supply ??= new();

            return supply;
        }

        public async Task<Supply?> GetByIngredient(ISpecification<Ingredient> objId)
        {
            Ingredient? ingredient = await _context.Ingredients.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == ingredient) return new();

            Supply? supply = await _context.Supplies.Where(c => c.SupplyId == ingredient.SupplyId).SingleOrDefaultAsync();

            if (null == supply) return new();

            return supply;
        }

        public async Task<Supply?> GetByStock(ISpecification<Stock> objId)
        {
            Stock? Stock = await _context.Stocks.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Stock) return new();

            Supply? supply = await _context.Supplies.Where(c => c.SupplyId == Stock.SupplyId).SingleOrDefaultAsync();

            if (null == supply) return new();

            return supply;
        }

        public async Task<IEnumerable<Supply>?> GetBySupplier(ISpecification<Supplier> objId)
        {
            Supplier? supplier = await _context.Suppliers.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supplier) return null;

            IEnumerable<Supply>? supply = await _context.Supplies.Where(c => c.SupplierId == supplier.SupplierId).ToListAsync();

            if (null == supply) return null;

            return supply;
        }

        public async Task<IEnumerable<Supply>?> GetByCategory(ISpecification<Supplycategory> objId)
        {
            Supplycategory? Supplycategory = await _context.Supplycategories.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Supplycategory) return null;

            IEnumerable<Supply>? supply = await _context.Supplies.Where(c => c.SupplyCategoryId == Supplycategory.SupplycategoryId).ToListAsync();

            if (null == supply) return null;

            return supply;
        }

        public async Task<Supply?> Save(ISpecification<Supply> objId, Supply obj)
        {
            Supply? supply = new();

            try
            {
                supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

                if (supply == null)
                    return supply;

                supply = obj;

                _context.Update(supply);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (supply == null) return new();
                if (!_context.Supplies.Any(c => c.SupplyId == supply.SupplyId))
                    return new();
                else throw;
            }

            return supply;
        }

        public async Task<IEnumerable<Supply>?> ToList(ISpecification<Supply> filterBy, ISpecification<Supply> orderBy)
        {
            return await _context.Supplies.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~SupplyRepository()
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
