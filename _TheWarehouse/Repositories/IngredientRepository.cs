
namespace TheWarehouse.Repositories
{
    public class IngredientRepository(ApplicationDbContext context) : IIngredients
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context = context;

        public async Task<Ingredient?> Create(Ingredient obj)
        {
            _context.Ingredients.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<Ingredient?> Delete(ISpecification<Ingredient> objId)
        {
            Ingredient? ingredient = await _context.Ingredients.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == ingredient) return ingredient;

            _context.Ingredients.Remove(ingredient);

            await _context.SaveChangesAsync();

            return ingredient;
        }

        public async Task<Ingredient?> GetById(ISpecification<Ingredient> objId)
        {
            if (null == objId)
                return new();

            Ingredient? ingredient = await _context.Ingredients.WithSpecification(objId).SingleOrDefaultAsync();

            ingredient ??= new();

            return ingredient;
        }

        public async Task<IEnumerable<Ingredient>?> GetByMenuItem(ISpecification<Menuitem> objId)
        {
           Menuitem? menuitem = await _context.Menuitems.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == menuitem) return null;

            IEnumerable<Ingredient>? ingredients = await _context.Ingredients.Where(i => i.MenuItemId == menuitem.MenuItemId).ToListAsync();

            if (null == ingredients) return null;

            return ingredients;
        }

        public async Task<IEnumerable<Ingredient>?> GetBySupply(ISpecification<Supply> objId)
        {
            Supply? supply = await _context.Supplies.WithSpecification(objId).SingleOrDefaultAsync();

            if (null == supply) return null;

            IEnumerable<Ingredient>? ingredients = await _context.Ingredients.Where(i => i.SupplyId == supply.SupplyId).ToListAsync();

            if (null == ingredients) return null;

            return ingredients;
        }

        public async Task<Ingredient?> Save(ISpecification<Ingredient> objId, Ingredient obj)
        {
            Ingredient? ingredient = new();

            try
            {
                ingredient = await _context.Ingredients.WithSpecification(objId).SingleOrDefaultAsync();

                if (ingredient == null)
                    return ingredient;

                ingredient = obj;

                _context.Update(ingredient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ingredient == null) return new();
                if (!_context.Ingredients.Any(i => i.IngredientId == ingredient.IngredientId))
                    return new();
                else throw;
            }

            return ingredient;
        }

        public async Task<IEnumerable<Ingredient>?> ToList(ISpecification<Ingredient> filterBy, ISpecification<Ingredient> orderBy)
        {
            return await _context.Ingredients.WithSpecification(filterBy).WithSpecification(orderBy).ToListAsync();
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
        // ~IngredientRepository()
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
