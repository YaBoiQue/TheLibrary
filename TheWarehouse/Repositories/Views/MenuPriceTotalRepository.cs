
namespace TheWarehouse.Repositories.Views
{
    public class MenuPriceTotalRepository : IMenuPriceTotal
    {
        private bool disposedValue;
        readonly private ApplicationDbContext _context;

        public MenuPriceTotalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MenuPriceTotal?> GetById(ISpecification<MenuPriceTotal> objId)
        {
            if (null == objId)
                return new();

            MenuPriceTotal? menupricetotal = await _context.Menupricetotals.WithSpecification(objId).SingleOrDefaultAsync();

            menupricetotal ??= new();

            return menupricetotal;
        }

        public async Task<IEnumerable<MenuPriceTotal>?> ToList(ISpecification<MenuPriceTotal> filterBy, ISpecification<MenuPriceTotal> orderBy)
        {
            return await _context.Menupricetotals.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~MenuPriceTotalRepository()
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
