namespace TheWarehouse.Repositories
{
    public class MenucategoryRepository(ApplicationDbContext context) : IMenucategories
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context = context;

        public async Task<Menucategory?> Create(Menucategory obj)
        {
            _context.Menucategories.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Menucategory?> Delete(ISpecification<Menucategory> objId)
        {
            Menucategory? Menucategory = await _context.Menucategories.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Menucategory) return new();

            _context.Menucategories.Remove(Menucategory);

            await _context.SaveChangesAsync();

            return Menucategory;
        }

        public async Task<Menucategory?> GetById(ISpecification<Menucategory> objId)
        {
            if (null == objId)
                return new();

            Menucategory? Menucategory = await _context.Menucategories.WithSpecification(objId).SingleOrDefaultAsync();

            Menucategory ??= new();

            return Menucategory;
        }

        public async Task<Menucategory?> GetByMenuItem(ISpecification<Menuitem> objId)
        {
            Menuitem? menuitem = await _context.Menuitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == menuitem) return new();

            Menucategory? Menucategory = await _context.Menucategories.Where(c => c.MenucategoryId == menuitem.MenucategoryId).SingleOrDefaultAsync();

            if (null == Menucategory) return new();

            return Menucategory;
        }

        public async Task<Menucategory?> Save(ISpecification<Menucategory> objId, Menucategory obj)
        {
            Menucategory? Menucategory = new();

            try
            {
                Menucategory = await _context.Menucategories.WithSpecification(objId).SingleOrDefaultAsync();

                if (Menucategory == null)
                    return Menucategory;

                Menucategory = obj;

                _context.Update(Menucategory);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Menucategory == null) return new();
                if (!_context.Menucategories.Any(c => c.MenucategoryId == Menucategory.MenucategoryId))
                    return new();
                else throw;
            }

            return Menucategory;
        }

        public async Task<IEnumerable<Menucategory>?> ToList(ISpecification<Menucategory> filterBy, ISpecification<Menucategory> orderBy)
        {
            return await _context.Menucategories.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~MenucategoryRepository()
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

        public override bool Equals(object? obj)
        {
            return obj is MenucategoryRepository repository &&
                   EqualityComparer<ApplicationDbContext>.Default.Equals(_context, repository._context);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_context);
        }
    }
}