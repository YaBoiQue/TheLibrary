namespace TheWarehouse.Controllers
{
    public class StockcodesController : BaseController
    {
        private readonly WarehouseDbContext _context;

        public StockcodesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Stockcodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stockcodes.ToListAsync());
        }

        // GET: Stockcodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockcode = await _context.Stockcodes
                .FirstOrDefaultAsync(m => m.Code == id);
            if (stockcode == null)
            {
                return NotFound();
            }

            return View(stockcode);
        }

        // GET: Stockcodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stockcodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Description")] Stockcode stockcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockcode);
        }

        // GET: Stockcodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockcode = await _context.Stockcodes.FindAsync(id);
            if (stockcode == null)
            {
                return NotFound();
            }
            return View(stockcode);
        }

        // POST: Stockcodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Description")] Stockcode stockcode)
        {
            if (id != stockcode.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockcodeExists(stockcode.Code))
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
            return View(stockcode);
        }

        // GET: Stockcodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockcode = await _context.Stockcodes
                .FirstOrDefaultAsync(m => m.Code == id);
            if (stockcode == null)
            {
                return NotFound();
            }

            return View(stockcode);
        }

        // POST: Stockcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stockcode = await _context.Stockcodes.FindAsync(id);
            if (stockcode != null)
            {
                _context.Stockcodes.Remove(stockcode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockcodeExists(string id)
        {
            return _context.Stockcodes.Any(e => e.Code == id);
        }
    }
}
