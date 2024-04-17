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

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId");
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,MenuitemId,SupplyId,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId", ingredient.MenuItemId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId", ingredient.SupplyId);
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
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId", ingredient.MenuItemId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId", ingredient.SupplyId);
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
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId", ingredient.MenuItemId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId", ingredient.SupplyId);
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
