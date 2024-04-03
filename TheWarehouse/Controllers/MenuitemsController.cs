namespace TheWarehouse.Controllers
{
    public class MenuitemsController : BaseController
    {
        private readonly WarehouseDbContext _context;

        public MenuitemsController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Menuitems
        public async Task<IActionResult> Index()
        {
            MenuitemViewModel viewModel = new MenuitemViewModel(await _context.Menuitems.Include(m => m.Menucategory).ToListAsync());

            foreach (var item in viewModel.menuitems)
            {
                item.Menucategory = _context.Menucategories.Where(c => c.MenucategoryId == item.MenucategoryId).FirstOrDefault();
            }
            return View(viewModel);
        }

        // GET: Menuitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems
                .Include(m => m.Menucategory)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            return View(menuitem);
        }

        // GET: Menuitems/Create
        public IActionResult Create()
        {
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId");
            return View();
        }

        // POST: Menuitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuItemId,Name,Price,MenucategoryId,Active,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Menuitem menuitem)
        {
            ModelState.Remove("UpdatedUserId");
            ModelState.Remove("CreatedUserId");
            if (ModelState.IsValid)
            {
                var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                menuitem.CreatedUserId = UserId;
                menuitem.UpdatedUserId = UserId;
                menuitem.CreatedTs = DateTime.UtcNow;
                menuitem.UpdatedTs = DateTime.UtcNow;
                _context.Add(menuitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId", menuitem.MenucategoryId);
            return View(menuitem);
        }

        // GET: Menuitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems.FindAsync(id);
            if (menuitem == null)
            {
                return NotFound();
            }
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId", menuitem.MenucategoryId);
            return View(menuitem);
        }

        // POST: Menuitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuItemId,Name,Price,MenucategoryId,Active,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Menuitem menuitem)
        {
            if (id != menuitem.MenuItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    menuitem.UpdatedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    menuitem.UpdatedTs = DateTime.UtcNow;
                    _context.Update(menuitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuitemExists(menuitem.MenuItemId))
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
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId", menuitem.MenucategoryId);
            return View(menuitem);
        }

        // GET: Menuitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems
                .Include(m => m.Menucategory)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            return View(menuitem);
        }

        // POST: Menuitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuitem = await _context.Menuitems.FindAsync(id);
            if (menuitem != null)
            {
                _context.Menuitems.Remove(menuitem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuitemExists(int id)
        {
            return _context.Menuitems.Any(e => e.MenuItemId == id);
        }
    }
}
