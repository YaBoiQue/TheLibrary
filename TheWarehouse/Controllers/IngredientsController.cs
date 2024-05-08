using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class IngredientsController : BaseController
    {
        private readonly WarehouseDbContext _context;

        public IngredientsController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Ingredients.Include(i => i.MenuItem).Include(i => i.Supply);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.MenuItem)
                .Include(i => i.Supply)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        public async Task<IActionResult> CreateFromMenuItem(int menuitemid)
        {
            Menuitem? menuitem = await _context.Menuitems.Where(m => m.MenuitemId == menuitemid).FirstOrDefaultAsync();

            if (menuitem == null)
                return View();

            Ingredient ingredient = new();

            ingredient.MenuItemId = menuitemid;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ingredient.CreatedUserId = userId;
            ingredient.UpdatedUserId = userId;

            ViewData["Supply"] = new SelectList(_context.Supplies, "SupplyId", "Name");


            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            Ingredient ingredient = new();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ingredient.CreatedUserId = userId;
            ingredient.UpdatedUserId = userId;
            ViewData["Menuitem"] = new SelectList(_context.Menuitems, "MenuitemId", "Name");
            ViewData["Supply"] = new SelectList(_context.Supplies, "SupplyId", "Name");
            return View(ingredient);
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,MenuItemId,SupplyId,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Ingredient ingredient)
        {
                if (ModelState.IsValid)
            {
                ingredient.CreatedTs = DateTime.Now;
                ingredient.UpdatedTs = DateTime.Now;

                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Menuitem"] = new SelectList(_context.Menuitems, "MenuitemId", "Name", ingredient.MenuItemId);
            ViewData["Supply"] = new SelectList(_context.Supplies, "SupplyId", "Name", ingredient.SupplyId);
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            ViewData["Menuitem"] = new SelectList(_context.Menuitems, "MenuitemId", "Name", ingredient.MenuItemId);
            ViewData["Supply"] = new SelectList(_context.Supplies, "SupplyId", "Name", ingredient.SupplyId);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,MenuitemId,SupplyId,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Menuitem"] = new SelectList(_context.Menuitems, "MenuitemId", "Name", ingredient.MenuItemId);
            ViewData["Supply"] = new SelectList(_context.Supplies, "SupplyId", "Name", ingredient.SupplyId);
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.MenuItem)
                .Include(i => i.Supply)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
