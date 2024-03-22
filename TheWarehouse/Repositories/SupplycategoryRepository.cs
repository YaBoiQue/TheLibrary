namespace TheWarehouse.Repositories
{
    public class SupplycategoryRepository(ApplicationDbContext context) : ISupplycategories
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Supplycategory?> Create(Supplycategory obj)
        {
            _context.Supplycategories.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Supplycategory?> Delete(ISpecification<Supplycategory> objId)
        {
            Supplycategory? Supplycategory = await _context.Supplycategories.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Supplycategory) return new();

            _context.Supplycategories.Remove(Supplycategory);

            await _context.SaveChangesAsync();

            return Supplycategory;
        }

        public async Task<Supplycategory?> GetById(ISpecification<Supplycategory> objId)
        {
            if (null == objId)
                return new();

            Supplycategory? Supplycategory = await _context.Supplycategories.WithSpecification(objId).SingleOrDefaultAsync();

            Supplycategory ??= new();

            return Supplycategory;
        }

        public async Task<Supplycategory?> GetBySupply(ISpecification<Supply> objId)
        {
            Supply? supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supply) return new();

            Supplycategory? Supplycategory = await _context.Supplycategories.Where(c => c.SupplycategoryId == supply.SupplyCategoryId).SingleOrDefaultAsync();

            if (null == Supplycategory) return new();

            return Supplycategory;
        }

        public async Task<Supplycategory?> Save(ISpecification<Supplycategory> objId, Supplycategory obj)
        {
            Supplycategory? Supplycategory = new();

            try
            {
                Supplycategory = await _context.Supplycategories.WithSpecification(objId).SingleOrDefaultAsync();

                if (Supplycategory == null)
                    return Supplycategory;

                Supplycategory = obj;

                _context.Update(Supplycategory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Supplycategory == null) return new();
                if (!_context.Supplycategories.Any(c => c.Name == Supplycategory.Name))
                    return new();
                else throw;
            }

            return Supplycategory;
        }

        public async Task<IEnumerable<Supplycategory>?> ToList(ISpecification<Supplycategory> filterBy, ISpecification<Supplycategory> orderBy)
        {
            return await _context.Supplycategories.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~SupplycategoryRepository()
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
