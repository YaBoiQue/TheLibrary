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
    public class TransactionsController : Controller
    {
        private readonly WarehouseDbContext _context;

        public TransactionsController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Transactions.Include(t => t.CodeNavigation).Include(t => t.Employee);
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
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.IdTransactions == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Name", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransactions,EmployeeId,Code,Timestamp")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Name", "Name", transaction.Code);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", transaction.EmployeeId);
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
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Name", "Name", transaction.Code);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", transaction.EmployeeId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransactions,EmployeeId,Code,Timestamp")] Transaction transaction)
        {
            if (id != transaction.IdTransactions)
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
                    if (!TransactionExists(transaction.IdTransactions))
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
            ViewData["Code"] = new SelectList(_context.Transactioncodes, "Name", "Name", transaction.Code);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", transaction.EmployeeId);
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
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.IdTransactions == id);
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
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.IdTransactions == id);
        }
    }
}
