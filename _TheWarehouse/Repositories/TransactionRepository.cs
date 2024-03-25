namespace TheWarehouse.Repositories
{
    public class TransactionRepository(ApplicationDbContext context) : ITransactions
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Transaction?> Create(Transaction obj)
        {
            _context.Transactions.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Transaction?> Delete(ISpecification<Transaction> objId)
        {
            Transaction? transaction = await _context.Transactions.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transaction) return new();

            _context.Transactions.Remove(transaction);

            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<IEnumerable<Transaction>?> GetByUser(ISpecification<User> objId)
        {
            User? employee = await _context.Users.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == employee) return null;

            IEnumerable<Transaction>? transactions = await _context.Transactions.Where(c => c.UserId == employee.Id).ToListAsync();

            if (null == transactions) return null;

            return transactions;
        }

        public async Task<Transaction?> GetById(ISpecification<Transaction> objId)
        {
            if (null == objId)
                return new();

            Transaction? transcation = await _context.Transactions.WithSpecification(objId).SingleOrDefaultAsync();

            transcation ??= new();

            return transcation;
        }

        public async Task<Transaction?> GetByTransactionItem(ISpecification<Transactionitem> objId)
        {
            Transactionitem? transactionitem = await _context.Transactionitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transactionitem) return new();

            Transaction? transaction = await _context.Transactions.Where(c => c.TransactionId == transactionitem.TransactionId).SingleOrDefaultAsync();

            if (null == transaction) return new();

            return transaction;
        }

        public async Task<IEnumerable<Transaction>?> GetByType(ISpecification<Transactioncode> objId)
        {
            Transactioncode? transactioncode = await _context.Transactioncodes.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transactioncode) return null;

            IEnumerable<Transaction>? transactions = await _context.Transactions.Where(c => c.Code == transactioncode.Code).ToListAsync();

            if (null == transactions) return null;

            return transactions;
        }

        public async Task<Transaction?> Save(ISpecification<Transaction> objId, Transaction obj)
        {
            Transaction? transaction = new();

            try
            {
                transaction = await _context.Transactions.WithSpecification(objId).SingleOrDefaultAsync();

                if (transaction == null)
                    return transaction;

                transaction = obj;

                _context.Update(transaction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (transaction == null) return new();
                if (!_context.Transactions.Any(c => c.TransactionId == transaction.TransactionId))
                    return new();
                else throw;
            }

            return transaction;
        }

        public async Task<IEnumerable<Transaction>?> ToList(ISpecification<Transaction> filterBy, ISpecification<Transaction> orderBy)
        {
            return await _context.Transactions.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~TransactionRepository()
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
