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
    public class InventoriesController : Controller
    {
        private readonly WarehouseDbContext _context;

        public InventoriesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Inventories.Include(i => i.CodeNavigation).Include(i => i.Employee).Include(i => i.Receipt).Include(i => i.Supply);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .Include(i => i.CodeNavigation)
                .Include(i => i.Employee)
                .Include(i => i.Receipt)
                .Include(i => i.Supply)
                .FirstOrDefaultAsync(m => m.IdInventory == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewData["Code"] = new SelectList(_context.Inventorycodes, "Name", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees");
            ViewData["ReceiptId"] = new SelectList(_context.Receipts, "IdReceipts", "IdReceipts");
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInventory,SupplyId,Amount,Price,EmployeeId,ReceiptId,Code,Timestamp")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Code"] = new SelectList(_context.Inventorycodes, "Name", "Name", inventory.Code);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", inventory.EmployeeId);
            ViewData["ReceiptId"] = new SelectList(_context.Receipts, "IdReceipts", "IdReceipts", inventory.ReceiptId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies", inventory.SupplyId);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["Code"] = new SelectList(_context.Inventorycodes, "Name", "Name", inventory.Code);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", inventory.EmployeeId);
            ViewData["ReceiptId"] = new SelectList(_context.Receipts, "IdReceipts", "IdReceipts", inventory.ReceiptId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies", inventory.SupplyId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInventory,SupplyId,Amount,Price,EmployeeId,ReceiptId,Code,Timestamp")] Inventory inventory)
        {
            if (id != inventory.IdInventory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.IdInventory))
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
            ViewData["Code"] = new SelectList(_context.Inventorycodes, "Name", "Name", inventory.Code);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "IdEmployees", "IdEmployees", inventory.EmployeeId);
            ViewData["ReceiptId"] = new SelectList(_context.Receipts, "IdReceipts", "IdReceipts", inventory.ReceiptId);
            ViewData["SupplyId"] = new SelectList(_context.Supplies, "IdSupplies", "IdSupplies", inventory.SupplyId);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .Include(i => i.CodeNavigation)
                .Include(i => i.Employee)
                .Include(i => i.Receipt)
                .Include(i => i.Supply)
                .FirstOrDefaultAsync(m => m.IdInventory == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventories.Remove(inventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.IdInventory == id);
        }
    }
}
