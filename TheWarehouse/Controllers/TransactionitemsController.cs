using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWarehouse.Data;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class TransactionitemsController : Controller
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
                .FirstOrDefaultAsync(m => m.IdTransactionItems == id);
            if (transactionitem == null)
            {
                return NotFound();
            }

            return View(transactionitem);
        }

        // GET: Transactionitems/Create
        public IActionResult Create()
        {
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems");
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "IdTransactions", "IdTransactions");
            return View();
        }

        // POST: Transactionitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransactionItems,TransactionId,MenuItemId,Count,Price,Timestamp")] Transactionitem transactionitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems", transactionitem.MenuItemId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "IdTransactions", "IdTransactions", transactionitem.TransactionId);
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
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems", transactionitem.MenuItemId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "IdTransactions", "IdTransactions", transactionitem.TransactionId);
            return View(transactionitem);
        }

        // POST: Transactionitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransactionItems,TransactionId,MenuItemId,Count,Price,Timestamp")] Transactionitem transactionitem)
        {
            if (id != transactionitem.IdTransactionItems)
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
                    if (!TransactionitemExists(transactionitem.IdTransactionItems))
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
            ViewData["MenuItemId"] = new SelectList(_context.Menuitems, "IdMenuItems", "IdMenuItems", transactionitem.MenuItemId);
            ViewData["TransactionId"] = new SelectList(_context.Transactions, "IdTransactions", "IdTransactions", transactionitem.TransactionId);
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
                .FirstOrDefaultAsync(m => m.IdTransactionItems == id);
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
            return _context.Transactionitems.Any(e => e.IdTransactionItems == id);
        }
    }
}
