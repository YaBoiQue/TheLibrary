namespace TheWarehouse.Repositories
{
    public class MenuitemRepository(ApplicationDbContext context) : IMenuitems
    {
        public readonly ApplicationDbContext _context = context;
        private bool disposedValue;

        public async Task<Menuitem?> Create(Menuitem obj)
        {
            _context.Menuitems.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Menuitem?> Delete(ISpecification<Menuitem> objId)
        {
            Menuitem? menuitem = await _context.Menuitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == menuitem) return new();

            _context.Menuitems.Remove(menuitem);

            await _context.SaveChangesAsync();

            return menuitem;
        }

        public async Task<IEnumerable<Menuitem>?> GetByCategory(ISpecification<Menucategory> objId)
        {
            Menucategory? Menucategory = await _context.Menucategories.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == Menucategory) return null;

            IEnumerable<Menuitem>? menuitem = await _context.Menuitems.Where(c => c.MenucategoryId == Menucategory.MenucategoryId).ToListAsync();

            if (null == menuitem) return null;

            return menuitem;
        }

        public async Task<Menuitem?> GetById(ISpecification<Menuitem> objId)
        {
            if (null == objId)
                return new();

            Menuitem? menuitem = await _context.Menuitems.WithSpecification(objId).SingleOrDefaultAsync();

            menuitem ??= new();

            return menuitem;
        }

        public async Task<Menuitem?> GetByIngredient(ISpecification<Ingredient> objId)
        {
            Ingredient? ingredient = await _context.Ingredients.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == ingredient) return null;

            Menuitem? menuitem = await _context.Menuitems.Where(c => c.MenuItemId == ingredient.MenuItemId).SingleOrDefaultAsync();

            if (null == menuitem) return null;

            return menuitem;

        }

        public async Task<Menuitem?> GetByTransactionItem(ISpecification<Transactionitem> objId)
        {
            Transactionitem? transactionitem = await _context.Transactionitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == transactionitem) return null;

            Menuitem? menuitem = await _context.Menuitems.Where(c => c.MenuItemId == transactionitem.MenuItemId).SingleOrDefaultAsync();

            if (null == menuitem) return null;

            return menuitem;
        }

        public async Task<Menuitem?> Save(ISpecification<Menuitem> objId, Menuitem obj)
        {
            Menuitem? menuitem = new();

            try
            {
                menuitem = await _context.Menuitems.WithSpecification(objId).SingleOrDefaultAsync();

                if (menuitem == null)
                    return menuitem;

                menuitem = obj;

                _context.Update(menuitem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (menuitem == null) return new();
                if (!_context.Menuitems.Any(c => c.MenuItemId == menuitem.MenuItemId))
                    return new();
                else throw;
            }

            return menuitem;
        }

        public async Task<IEnumerable<Menuitem>?> ToList(ISpecification<Menuitem> filterBy, ISpecification<Menuitem> orderBy)
        {
            return await _context.Menuitems.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~MenuitemRepository()
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
