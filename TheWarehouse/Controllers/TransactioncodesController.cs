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
    public class TransactioncodesController : Controller
    {
        private readonly WarehouseDbContext _context;

        public TransactioncodesController(WarehouseDbContext context)
        {
            _context = context;
        }

        // GET: Transactioncodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactioncodes.ToListAsync());
        }

        // GET: Transactioncodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactioncode = await _context.Transactioncodes
                .FirstOrDefaultAsync(m => m.Name == id);
            if (transactioncode == null)
            {
                return NotFound();
            }

            return View(transactioncode);
        }

        // GET: Transactioncodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactioncodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] Transactioncode transactioncode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactioncode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactioncode);
        }

        // GET: Transactioncodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactioncode = await _context.Transactioncodes.FindAsync(id);
            if (transactioncode == null)
            {
                return NotFound();
            }
            return View(transactioncode);
        }

        // POST: Transactioncodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description")] Transactioncode transactioncode)
        {
            if (id != transactioncode.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactioncode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactioncodeExists(transactioncode.Name))
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
            return View(transactioncode);
        }

        // GET: Transactioncodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactioncode = await _context.Transactioncodes
                .FirstOrDefaultAsync(m => m.Name == id);
            if (transactioncode == null)
            {
                return NotFound();
            }

            return View(transactioncode);
        }

        // POST: Transactioncodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transactioncode = await _context.Transactioncodes.FindAsync(id);
            if (transactioncode != null)
            {
                _context.Transactioncodes.Remove(transactioncode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactioncodeExists(string id)
        {
            return _context.Transactioncodes.Any(e => e.Name == id);
        }
    }
}
