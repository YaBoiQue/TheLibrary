using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class MenuitemsController : BaseController
    {
        private readonly WarehouseDbContext _context;
        private readonly string _basePath;

        public MenuitemsController(WarehouseDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _basePath = Path.Combine(hostEnvironment.WebRootPath, "img/", "menuitems/");
        }

        // GET: Menuitems
        public async Task<IActionResult> Index()
        {
            MenuitemViewModel viewModel = new MenuitemViewModel(await _context.Menuitems.Include(m => m.Menucategory).ToListAsync());

            foreach (var item in viewModel.menuitems)
            {
                item.Menucategory = _context.Menucategories.Where(c => c.MenucategoryId == item.MenucategoryId).FirstOrDefault();
            }
            return View(viewModel);
        }
        // GET: Menuitems by Menucategory
        public async Task<IActionResult> ListbyCategory(int? id)
        {
            List<Menuitem> menuitems = [];
            if (id != null)
                menuitems = await _context.Menuitems.Where(m => m.MenucategoryId == id).Include(m => m.Menucategory).ToListAsync();
            else menuitems = await _context.Menuitems.Include(m => m.Menucategory).ToListAsync();

            foreach (Menuitem item in menuitems)
            {
                item.ImagePath = Url.Content("~/img/menuitems/" + item.ImageName);
                item.Menucategory = _context.Menucategories.Where(c => c.MenucategoryId == item.MenucategoryId).FirstOrDefault();
            }
            return View("Menu", menuitems);
        }

        // GET: Menuitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems
                .Include(m => m.Menucategory)
                .FirstOrDefaultAsync(m => m.MenuitemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            menuitem.ImagePath = Url.Content("~/img/menuitems/" + menuitem.ImageName);

            return View(menuitem);
        }

        // GET: Menuitems/Create
        public IActionResult Create()
        {
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "Name");
            return View();
        }

        // POST: Menuitems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuitemId,Name,Price,MenucategoryId,ImageFile,Active,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Menuitem menuitem)
        {
            ModelState.Remove("UpdatedUserId");
            ModelState.Remove("CreatedUserId");
            if (ModelState.IsValid)
            {
                //Save image to wwroot/img/menuCategories
                if (menuitem.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(menuitem.ImageFile.FileName);
                    string extension = Path.GetExtension(menuitem.ImageFile.FileName).ToLower();
                    menuitem.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    menuitem.ImagePath = Path.Combine(_basePath + fileName);

                    using (var fileStream = new FileStream(menuitem.ImagePath, FileMode.Create))
                    {
                        await menuitem.ImageFile.CopyToAsync(fileStream);
                    }
                }

                //Insert record
                var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                menuitem.CreatedUserId = UserId;
                menuitem.UpdatedUserId = UserId;
                menuitem.CreatedTs = DateTime.UtcNow;
                menuitem.UpdatedTs = DateTime.UtcNow;
                _context.Add(menuitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId", menuitem.MenucategoryId);
            return View(menuitem);
        }

        // GET: Menuitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems.FindAsync(id);
            if (menuitem == null)
            {
                return NotFound();
            }
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId", menuitem.MenucategoryId);
            return View(menuitem);
        }

        // POST: Menuitems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuitemId,Name,Price,MenucategoryId,ImageName,ImageFile,Active,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId")] Menuitem menuitem)
        {
            if (id != menuitem.MenuitemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Save image to wwroot/img/menuCategories
                    if (menuitem.ImageFile != null)
                    {
                        string path = Path.Combine(_basePath + menuitem.ImageName);
                        FileInfo fi = new FileInfo(path);
                        if (fi.Exists)
                            fi.Delete();

                        string fileName = Path.GetFileNameWithoutExtension(menuitem.ImageFile.FileName);
                        string extension = Path.GetExtension(menuitem.ImageFile.FileName).ToLower();
                        menuitem.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                        path = Path.Combine(_basePath + fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await menuitem.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    menuitem.UpdatedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    menuitem.UpdatedTs = DateTime.UtcNow;
                    _context.Update(menuitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuitemExists(menuitem.MenuitemId))
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
            ViewData["MenucategoryId"] = new SelectList(_context.Menucategories, "MenucategoryId", "MenucategoryId", menuitem.MenucategoryId);
            return View(menuitem);
        }

        // GET: Menuitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.Menuitems
                .Include(m => m.Menucategory)
                .FirstOrDefaultAsync(m => m.MenuitemId == id);
            if (menuitem == null)
            {
                return NotFound();
            }

            return View(menuitem);
        }

        // POST: Menuitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuitem = await _context.Menuitems.FindAsync(id);
            if (menuitem != null)
            {
                string path = Path.Combine("~/img/menuitems/" + menuitem.ImageName);
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                    fi.Delete();
                _context.Menuitems.Remove(menuitem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuitemExists(int id)
        {
            return _context.Menuitems.Any(e => e.MenuitemId == id);
        }
    }
}
