namespace TheWarehouse.Controllers
{
    public class MenucategoriesController : BaseController
    {
        private readonly WarehouseDbContext _context;

        public MenucategoriesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Menucategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menucategories.ToListAsync());
        }

        // GET: Menucategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucategory = await _context.Menucategories
                .FirstOrDefaultAsync(m => m.MenucategoryId == id);
            if (menucategory == null)
            {
                return NotFound();
            }

            return View(menucategory);
        }

        // GET: Menucategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menucategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenucategoryId,Name")] Menucategory menucategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menucategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menucategory);
        }

        // GET: Menucategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucategory = await _context.Menucategories.FindAsync(id);
            if (menucategory == null)
            {
                return NotFound();
            }
            return View(menucategory);
        }

        // POST: Menucategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenucategoryId,Name")] Menucategory menucategory)
        {
            if (id != menucategory.MenucategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menucategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenucategoryExists(menucategory.MenucategoryId))
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
            return View(menucategory);
        }

        // GET: Menucategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucategory = await _context.Menucategories
                .FirstOrDefaultAsync(m => m.MenucategoryId == id);
            if (menucategory == null)
            {
                return NotFound();
            }

            return View(menucategory);
        }

        // POST: Menucategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menucategory = await _context.Menucategories.FindAsync(id);
            if (menucategory != null)
            {
                _context.Menucategories.Remove(menucategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenucategoryExists(int id)
        {
            return _context.Menucategories.Any(e => e.MenucategoryId == id);
        }
    }
}
