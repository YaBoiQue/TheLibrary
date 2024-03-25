namespace TheWarehouse.Repositories
{
    public class StockcodeRepository(ApplicationDbContext context) : IStockcodes
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Stockcode?> Create(Stockcode obj)
        {
            _context.Stockcodes.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Stockcode?> Delete(ISpecification<Stockcode> objId)
        {
            Stockcode? Stockcode = await _context.Stockcodes.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Stockcode) return new();

            _context.Stockcodes.Remove(Stockcode);

            await _context.SaveChangesAsync();

            return Stockcode;
        }

        public async Task<Stockcode?> GetById(ISpecification<Stockcode> objId)
        {
            if (null == objId)
                return new();

            Stockcode? Stockcode = await _context.Stockcodes.WithSpecification(objId).SingleOrDefaultAsync();

            Stockcode ??= new();

            return Stockcode;
        }

        public async Task<Stockcode?> GetByStock(ISpecification<Stock> objId)
        {
            Stock? Stock = await _context.Stocks.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Stock) return new();

            Stockcode? Stockcode = await _context.Stockcodes.Where(i => i.Code == Stock.Code).SingleOrDefaultAsync();

            if (null == Stockcode) return new();

            return Stockcode;
        }

        public async Task<Stockcode?> Save(ISpecification<Stockcode> objId, Stockcode obj)
        {
            Stockcode? Stockcode = new();

            try
            {
                Stockcode = await _context.Stockcodes.WithSpecification(objId).SingleOrDefaultAsync();

                if (Stockcode == null)
                    return Stockcode;

                Stockcode = obj;

                _context.Update(Stockcode);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Stockcode == null) return new();
                if (!_context.Stockcodes.Any(c => c.Code == Stockcode.Code))
                    return new();
                else throw;
            }

            return Stockcode;
        }

        public async Task<IEnumerable<Stockcode>?> ToList(ISpecification<Stockcode> filterBy, ISpecification<Stockcode> orderBy)
        {
            return await _context.Stockcodes.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~StockcodeRepository()
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
