using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TheWarehouse.Data;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class StockreceiptsController(WarehouseDbContext context, IHttpContextAccessor contx) : Controller
    {
        private readonly WarehouseDbContext _context = context;
        private readonly IHttpContextAccessor _contx = contx;


        // GET: Stockreceipts
        public async Task<IActionResult> Index()
        {
            var warehouseDbContext = _context.Stockreceipt.Include(s => s.Supplier);
            return View(await warehouseDbContext.ToListAsync());
        }

        // GET: Stockreceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockreceipt = await _context.Stockreceipt
                .Include(s => s.Supplier)
                .Include(s => s.Stocks)
                .FirstOrDefaultAsync(m => m.StockreceiptId == id);
            if (stockreceipt == null)
            {
                return NotFound();
            }

            return View(stockreceipt);
        }

        public async Task<IActionResult> AddStock()
        {
            return View();
        }

        // GET: Stockreceipts/Create
        public IActionResult Create()
        {
            Stockreceipt stockreceipt = new();
            String? tempStr = _contx.HttpContext.Session.GetString("Stocks");

            if (tempStr == null)
            {
                _contx.HttpContext.Session.SetString("Stocks", JsonConvert.SerializeObject(new List<Stock>()));
                tempStr = _contx.HttpContext.Session.GetString("Stocks");
            }
            List<Stock>? stocks = JsonConvert.DeserializeObject<List<Stock>>(tempStr);
            stocks ??= [];

            stockreceipt.Stocks = stocks;

            return View(stockreceipt);
        }

        // POST: Stockreceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockreceiptId,SupplierId,DateTimePurchased,ImageName,Timestamp,UserId")] Stockreceipt stockreceipt)
        {
            if (ModelState.IsValid)
            {
                String? tempStr = _contx.HttpContext.Session.GetString("Stocks");

                if (tempStr == null)
                {
                    _contx.HttpContext.Session.SetString("Stocks", JsonConvert.SerializeObject(new List<Stock>()));
                    tempStr = _contx.HttpContext.Session.GetString("Stocks");
                }
                List<Stock>? stocks = JsonConvert.DeserializeObject<List<Stock>>(tempStr);
                stocks ??= [];

                stockreceipt.Stocks = stocks;

                _context.Add(stockreceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Name", stockreceipt.SupplierId);
            return View(stockreceipt);
        }

        // GET: Stockreceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockreceipt = await _context.Stockreceipt.FindAsync(id);
            if (stockreceipt == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Name", stockreceipt.SupplierId);

            stockreceipt.Stocks = await _context.Stocks.Where(s => s.StockreceiptId == stockreceipt.StockreceiptId).ToListAsync();
            stockreceipt.Supplier = await _context.Suppliers.Where(s => s.SupplierId == stockreceipt.SupplierId).FirstOrDefaultAsync();

            return View(stockreceipt);
        }

        // POST: Stockreceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockreceiptId,SupplierId,DateTimePurchased,ImageName,Timestamp,UserId")] Stockreceipt stockreceipt)
        {
            if (id != stockreceipt.StockreceiptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockreceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockreceiptExists(stockreceipt.StockreceiptId))
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
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Name", stockreceipt.SupplierId);
            return View(stockreceipt);
        }

        // GET: Stockreceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockreceipt = await _context.Stockreceipt
                .Include(s => s.Supplier)
                .Include(s => s.Stocks)
                .FirstOrDefaultAsync(m => m.StockreceiptId == id);
            if (stockreceipt == null)
            {
                return NotFound();
            }

            return View(stockreceipt);
        }

        // POST: Stockreceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockreceipt = await _context.Stockreceipt.FindAsync(id);
            if (stockreceipt != null)
            {
                _context.Stockreceipt.Remove(stockreceipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockreceiptExists(int id)
        {
            return _context.Stockreceipt.Any(e => e.StockreceiptId == id);
        }
    }
}
