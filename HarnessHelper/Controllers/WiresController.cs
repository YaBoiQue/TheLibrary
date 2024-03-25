using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HarnessHelper.Data;
using HarnessHelper.Models;

namespace HarnessHelper.Controllers
{
    public class WiresController : Controller
    {
        private readonly HarnessDbContext _context;

        public WiresController(HarnessDbContext context)
        {
            _context = context;
        }

        // GET: Wires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wires.ToListAsync());
        }

        // GET: Wires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wire = await _context.Wires
                .FirstOrDefaultAsync(m => m.WireId == id);
            if (wire == null)
            {
                return NotFound();
            }

            return View(wire);
        }

        // GET: Wires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WireId,ColorCode,Gauge,Description,UserId")] Wire wire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wire);
        }

        // GET: Wires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wire = await _context.Wires.FindAsync(id);
            if (wire == null)
            {
                return NotFound();
            }
            return View(wire);
        }

        // POST: Wires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WireId,ColorCode,Gauge,Description,UserId")] Wire wire)
        {
            if (id != wire.WireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WireExists(wire.WireId))
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
            return View(wire);
        }

        // GET: Wires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wire = await _context.Wires
                .FirstOrDefaultAsync(m => m.WireId == id);
            if (wire == null)
            {
                return NotFound();
            }

            return View(wire);
        }

        // POST: Wires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wire = await _context.Wires.FindAsync(id);
            if (wire != null)
            {
                _context.Wires.Remove(wire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WireExists(int id)
        {
            return _context.Wires.Any(e => e.WireId == id);
        }
    }
}
