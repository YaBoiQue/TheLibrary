namespace TheWarehouse.Controllers
{
    public class SuppliesController : BaseController
    {
        private readonly WarehouseDbContext _context;

        public SuppliesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Supplies.Include(s => s.Supplier).Include(s => s.SupplyCategory);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supplies
                .Include(s => s.Supplier)
                .Include(s => s.SupplyCategory)
                .FirstOrDefaultAsync(m => m.SupplyId == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            ViewData["Supplier"] = new SelectList(_context.Suppliers, "SupplierId", "Name");
            ViewData["SupplyCategory"] = new SelectList(_context.Supplycategories, "SupplycategoryId", "Name");

            Supply supply = new();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            supply.CreatedUserId = userId;
            supply.UpdatedUserId = userId;

            return View(supply);
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyId,Name,SupplyCategoryId,SupplierId,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                supply.CreatedTs = DateTime.Now;
                supply.UpdatedTs = DateTime.Now;

                _context.Add(supply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Supplier"] = new SelectList(_context.Suppliers, "SupplierId", "Name", supply.SupplierId);
            ViewData["SupplyCategory"] = new SelectList(_context.Supplycategories, "SupplycategoryId", "Name", supply.SupplyCategoryId);
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supplies.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            ViewData["Supplier"] = new SelectList(_context.Suppliers, "SupplierId", "Name", supply.SupplierId);
            ViewData["supplyCategory"] = new SelectList(_context.Supplycategories, "SupplycategoryId", "Name", supply.SupplyCategoryId);
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyId,Name,SupplyCategoryId,SupplierId,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Supply supply)
        {
            if (id != supply.SupplyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.SupplyId))
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
            ViewData["Supplier"] = new SelectList(_context.Suppliers, "SupplierId", "Name", supply.SupplierId);
            ViewData["SupplyCategory"] = new SelectList(_context.Supplycategories, "SupplycategoryId", "Name", supply.SupplyCategoryId);
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _context.Supplies
                .Include(s => s.Supplier)
                .Include(s => s.SupplyCategory)
                .FirstOrDefaultAsync(m => m.SupplyId == id);
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supply = await _context.Supplies.FindAsync(id);
            if (supply != null)
            {
                _context.Supplies.Remove(supply);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
            return _context.Supplies.Any(e => e.SupplyId == id);
        }
    }
}
