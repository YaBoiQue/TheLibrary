using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TheWarehouse.Controllers
{
    public class TransactionsController(WarehouseDbContext context, IHttpContextAccessor contx) : BaseController
    {
        private readonly WarehouseDbContext _context = context;
        private readonly IHttpContextAccessor _contx = contx;
        private readonly CartController _cart = new(context, contx);
        private readonly TransactionitemsController _transitems = new(context);
        
        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Transactions.Include(t => t.CodeNavigation);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.CodeNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        public async Task<IActionResult> CreateFromCart()
        {
            Transaction? transaction = new();

            transaction.Timestamp = DateTime.Now;
            transaction.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Cartitem> cartitems = _cart.GetCart();
            
            if (cartitems == null)
                return RedirectToAction("Index");

            foreach(Cartitem item in cartitems)
            {
                transaction.Transactionitems.Add(new Transactionitem(item.Menuitem.MenuitemId, (item.Menuitem.Price ??= 0), item.Quantity));
            }

            _context.Add(transaction);
            await _context.SaveChangesAsync();
            _cart.Clear();

            return RedirectToAction("Details", new { id = transaction.TransactionId });
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Code", "Code");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,Code,Timestamp,UserId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Code", "Code", transaction.Code);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Code", "Code", transaction.Code);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,Code,Timestamp,UserId")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
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
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Code", "Code", transaction.Code);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.CodeNavigation)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.Include(t => t.Transactionitems).Where(t => t.TransactionId == id).FirstOrDefaultAsync();
            if (transaction != null)
            {
                foreach (Transactionitem item in transaction.Transactionitems)
                {
                    _context.Transactionitems.Remove(item);
                }
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
