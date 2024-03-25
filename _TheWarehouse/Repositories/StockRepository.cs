namespace TheWarehouse.Repositories
{
    public class StockRepository(ApplicationDbContext context) : IStocks
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Stock?> Create(Stock obj)
        {
            _context.Stocks.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Stock?> Delete(ISpecification<Stock> objId)
        {
            Stock? Stock = await _context.Stocks.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Stock) return new();

            _context.Stocks.Remove(Stock);

            await _context.SaveChangesAsync();

            return Stock;
        }

        public async Task<IEnumerable<Stock>?> GetByUser(ISpecification<User> objId)
        {
            User? employee = await _context.Users.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == employee) return null;

            IEnumerable<Stock>? Stocks = await _context.Stocks.Where(c => c.UserId == employee.Id).ToListAsync();

            if (null == Stocks) return null;

            return Stocks;
        }

        public async Task<Stock?> GetById(ISpecification<Stock> objId)
        {
            if (null == objId)
                return new();

            Stock? Stock = await _context.Stocks.WithSpecification(objId).SingleOrDefaultAsync();

            Stock ??= new();

            return Stock;
        }

        public async Task<IEnumerable<Stock>?> GetBySupply(ISpecification<Supply> objId)
        {
            Supply? supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supply) return null;

            IEnumerable<Stock>? Stocks = await _context.Stocks.Where(c => c.SupplyId == supply.SupplyId).ToListAsync();

            if (null == Stocks) return null;

            return Stocks;
        }

        public async Task<IEnumerable<Stock>?> GetByCode(ISpecification<Stockcode> objId)
        {
            Stockcode? Stockcode = await _context.Stockcodes.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Stockcode) return null;

            IEnumerable<Stock>? Stocks = await _context.Stocks.Where(c => c.Code == Stockcode.Code).ToListAsync();

            if (null == Stocks) return null;

            return Stocks;
        }

        public async Task<Stock?> Save(ISpecification<Stock> objId, Stock obj)
        {
            Stock? Stock = new();

            try
            {
                Stock = await _context.Stocks.WithSpecification(objId).SingleOrDefaultAsync();

                if (Stock == null)
                    return Stock;

                Stock = obj;

                _context.Update(Stock);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Stock == null) return new();
                if (!_context.Stocks.Any(i => i.StockId == Stock.StockId))
                    return new();
                else throw;
            }

            return Stock;
        }

        public async Task<IEnumerable<Stock>?> ToList(ISpecification<Stock> filterBy, ISpecification<Stock> orderBy)
        {
            return await _context.Stocks.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~StockRepository()
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
