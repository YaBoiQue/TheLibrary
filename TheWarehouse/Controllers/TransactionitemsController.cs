namespace TheWarehouse.Controllers
{
    public class TransactionitemsController : BaseController
    {
        private readonly WarehouseDbContext _context;

        public TransactionitemsController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Transactionitems
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Transactionitems.Include(t => t.MenuItem).Include(t => t.Transaction);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Transactionitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionitem = await _context.Transactionitems
                .Include(t => t.MenuItem)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.TransactionItemId == id);
            if (transactionitem == null)
            {
                return NotFound();
            }

            return View(transactionitem);
        }

        // GET: Transactionitems/Create
        public IActionResult Create()
        {
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId");
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId");
            return View();
        }

        // POST: Transactionitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionItemId,TransactionId,MenuitemId,Count,Price,Timestamp")] Transactionitem transactionitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId", transactionitem.MenuItemId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", transactionitem.TransactionId);
            return View(transactionitem);
        }

        // GET: Transactionitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionitem = await _context.Transactionitems.FindAsync(id);
            if (transactionitem == null)
            {
                return NotFound();
            }
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId", transactionitem.MenuItemId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", transactionitem.TransactionId);
            return View(transactionitem);
        }

        // POST: Transactionitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionItemId,TransactionId,MenuitemId,Count,Price,Timestamp")] Transactionitem transactionitem)
        {
            if (id != transactionitem.TransactionItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionitemExists(transactionitem.TransactionItemId))
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
            ViewData["MenuitemId"] = new SelectList(_context.Menuitems, "MenuitemId", "MenuitemId", transactionitem.MenuItemId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "TransactionId", "TransactionId", transactionitem.TransactionId);
            return View(transactionitem);
        }

        // GET: Transactionitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionitem = await _context.Transactionitems
                .Include(t => t.MenuItem)
                .Include(t => t.Transaction)
                .FirstOrDefaultAsync(m => m.TransactionItemId == id);
            if (transactionitem == null)
            {
                return NotFound();
            }

            return View(transactionitem);
        }

        // POST: Transactionitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionitem = await _context.Transactionitems.FindAsync(id);
            if (transactionitem != null)
            {
                _context.Transactionitems.Remove(transactionitem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionitemExists(int id)
        {
            return _context.Transactionitems.Any(e => e.TransactionItemId == id);
        }
    }
}
