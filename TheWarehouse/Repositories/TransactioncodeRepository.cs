namespace TheWarehouse.Repositories
{
    public class TransactioncodeRepository(ApplicationDbContext context) : ITransactioncodes
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Transactioncode?> Create(Transactioncode obj)
        {
            _context.Transactioncodes.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Transactioncode?> Delete(ISpecification<Transactioncode> objId)
        {
            Transactioncode? transactioncode = await _context.Transactioncodes.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transactioncode) return new();

            _context.Transactioncodes.Remove(transactioncode);

            await _context.SaveChangesAsync();

            return transactioncode;
        }

        public async Task<Transactioncode?> GetById(ISpecification<Transactioncode> objId)
        {
            if (null == objId)
                return new();

            Transactioncode? transactioncode = await _context.Transactioncodes.WithSpecification(objId).SingleOrDefaultAsync();

            transactioncode ??= new();

            return transactioncode;
        }

        public async Task<Transactioncode?> GetByTransaction(ISpecification<Transaction> objId)
        {
            Transaction? transaction = await _context.Transactions.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transaction) return new();

            Transactioncode? transactioncode = await _context.Transactioncodes.Where(c => c.Code == transaction.Code).SingleOrDefaultAsync();

            if (null == transactioncode) return new();

            return transactioncode;
        }

        public async Task<Transactioncode?> Save(ISpecification<Transactioncode> objId, Transactioncode obj)
        {
            Transactioncode? transactioncode = new();

            try
            {
                transactioncode = await _context.Transactioncodes.WithSpecification(objId).SingleOrDefaultAsync();

                if (transactioncode == null)
                    return transactioncode;

                transactioncode = obj;

                _context.Update(transactioncode);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (transactioncode == null) return new();
                if (!_context.Transactioncodes.Any(c => c.Code == transactioncode.Code))
                    return new();
                else throw;
            }

            return transactioncode;
        }

        public async Task<IEnumerable<Transactioncode>?> ToList(ISpecification<Transactioncode> filterBy, ISpecification<Transactioncode> orderBy)
        {
            return await _context.Transactioncodes.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~TransactioncodeRepository()
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
