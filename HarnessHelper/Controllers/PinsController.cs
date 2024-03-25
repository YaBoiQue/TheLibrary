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
    public class PinsController : Controller
    {
        private readonly HarnessDbContext _context;

        public PinsController(HarnessDbContext context)
        {
            _context = context;
        }

        // GET: Pins
        public async Task<IActionResult> Index()
        {
            var harnessDbContext = _context.Pins.Include(p => p.Plug).Include(p => p.Wire);
            return View(await harnessDbContext.ToListAsync());
        }

        // GET: Pins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pin = await _context.Pins
                .Include(p => p.Plug)
                .Include(p => p.Wire)
                .FirstOrDefaultAsync(m => m.PinId == id);
            if (pin == null)
            {
                return NotFound();
            }

            return View(pin);
        }

        // GET: Pins/Create
        public IActionResult Create()
        {
            ViewData["PlugId"] = new SelectList(_context.Plugs, "PlugId", "PlugId");
            ViewData["WireId"] = new SelectList(_context.Wires, "WireId", "WireId");
            return View();
        }

        // POST: Pins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PinId,PlugId,WireId,Position,UserId")] Pin pin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlugId"] = new SelectList(_context.Plugs, "PlugId", "PlugId", pin.PlugId);
            ViewData["WireId"] = new SelectList(_context.Wires, "WireId", "WireId", pin.WireId);
            return View(pin);
        }

        // GET: Pins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pin = await _context.Pins.FindAsync(id);
            if (pin == null)
            {
                return NotFound();
            }
            ViewData["PlugId"] = new SelectList(_context.Plugs, "PlugId", "PlugId", pin.PlugId);
            ViewData["WireId"] = new SelectList(_context.Wires, "WireId", "WireId", pin.WireId);
            return View(pin);
        }

        // POST: Pins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PinId,PlugId,WireId,Position,UserId")] Pin pin)
        {
            if (id != pin.PinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PinExists(pin.PinId))
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
            ViewData["PlugId"] = new SelectList(_context.Plugs, "PlugId", "PlugId", pin.PlugId);
            ViewData["WireId"] = new SelectList(_context.Wires, "WireId", "WireId", pin.WireId);
            return View(pin);
        }

        // GET: Pins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pin = await _context.Pins
                .Include(p => p.Plug)
                .Include(p => p.Wire)
                .FirstOrDefaultAsync(m => m.PinId == id);
            if (pin == null)
            {
                return NotFound();
            }

            return View(pin);
        }

        // POST: Pins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pin = await _context.Pins.FindAsync(id);
            if (pin != null)
            {
                _context.Pins.Remove(pin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PinExists(int id)
        {
            return _context.Pins.Any(e => e.PinId == id);
        }
    }
}
