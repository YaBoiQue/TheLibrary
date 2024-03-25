namespace TheWarehouse.Repositories
{
    public class TransactionitemRepository(ApplicationDbContext context) : ITransactionitems
    {
        private readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Transactionitem?> Create(Transactionitem obj)
        {
            _context.Transactionitems.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Transactionitem?> Delete(ISpecification<Transactionitem> objId)
        {
            Transactionitem? transactionitem = await _context.Transactionitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transactionitem) return new();

            _context.Transactionitems.Remove(transactionitem);

            await _context.SaveChangesAsync();

            return transactionitem;
        }

        public async Task<Transactionitem?> GetById(ISpecification<Transactionitem> objId)
        {
            if (null == objId)
                return new();

            Transactionitem? transactionitem = await _context.Transactionitems.WithSpecification(objId).SingleOrDefaultAsync();

            transactionitem ??= new();

            return transactionitem;
        }

        public async Task<IEnumerable<Transactionitem>?> GetByMenuItem(ISpecification<Menuitem> objId)
        {
            Menuitem? menuitem = await _context.Menuitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == menuitem) return null;

            IEnumerable<Transactionitem>? transactionitems = await _context.Transactionitems.Where(c => c.MenuItemId == menuitem.MenuItemId).ToListAsync();

            if (null == transactionitems) return null;

            return transactionitems;
        }

        public async Task<IEnumerable<Transactionitem>?> GetByTransaction(ISpecification<Transaction> objId)
        {
            Transaction? transaction = await _context.Transactions.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transaction) return null;

            IEnumerable<Transactionitem>? transactionitems = await _context.Transactionitems.Where(c => c.TransactionId == transaction.TransactionId).ToListAsync();

            if (null == transactionitems) return null;

            return transactionitems;
        }

        public async Task<Transactionitem?> Save(ISpecification<Transactionitem> objId, Transactionitem obj)
        {
            Transactionitem? transactionitem = new();

            try
            {
                transactionitem = await _context.Transactionitems.WithSpecification(objId).SingleOrDefaultAsync();

                if (transactionitem == null)
                    return transactionitem;

                transactionitem = obj;

                _context.Update(transactionitem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (transactionitem == null) return new();
                if (!_context.Transactionitems.Any(c => c.TransactionItemId == transactionitem.TransactionItemId))
                    return new();
                else throw;
            }

            return transactionitem;
        }

        public async Task<IEnumerable<Transactionitem>?> ToList(ISpecification<Transactionitem> filterBy, ISpecification<Transactionitem> orderBy)
        {
            return await _context.Transactionitems.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~TransactionitemRepository()
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
