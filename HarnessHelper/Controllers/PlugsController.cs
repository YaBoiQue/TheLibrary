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
    public class PlugsController : Controller
    {
        private readonly HarnessDbContext _context;

        public PlugsController(HarnessDbContext context)
        {
            _context = context;
        }

        // GET: Plugs
        public async Task<IActionResult> Index()
        {
            var harnessDbContext = _context.Plugs.Include(p => p.Device);
            return View(await harnessDbContext.ToListAsync());
        }

        // GET: Plugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plug = await _context.Plugs
                .Include(p => p.Device)
                .FirstOrDefaultAsync(m => m.PlugId == id);
            if (plug == null)
            {
                return NotFound();
            }

            return View(plug);
        }

        // GET: Plugs/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceId");
            return View();
        }

        // POST: Plugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlugId,DeviceId,Name,NumPinHoles,Description,UserId")] Plug plug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceId", plug.DeviceId);
            return View(plug);
        }

        // GET: Plugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plug = await _context.Plugs.FindAsync(id);
            if (plug == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceId", plug.DeviceId);
            return View(plug);
        }

        // POST: Plugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlugId,DeviceId,Name,NumPinHoles,Description,UserId")] Plug plug)
        {
            if (id != plug.PlugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlugExists(plug.PlugId))
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
            ViewData["DeviceId"] = new SelectList(_context.Devices, "DeviceId", "DeviceId", plug.DeviceId);
            return View(plug);
        }

        // GET: Plugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plug = await _context.Plugs
                .Include(p => p.Device)
                .FirstOrDefaultAsync(m => m.PlugId == id);
            if (plug == null)
            {
                return NotFound();
            }

            return View(plug);
        }

        // POST: Plugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plug = await _context.Plugs.FindAsync(id);
            if (plug != null)
            {
                _context.Plugs.Remove(plug);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlugExists(int id)
        {
            return _context.Plugs.Any(e => e.PlugId == id);
        }
    }
}
