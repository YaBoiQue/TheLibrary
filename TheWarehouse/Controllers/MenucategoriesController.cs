using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class MenucategoriesController : BaseController
    {
        private readonly WarehouseDbContext _context;
        private readonly string _basePath;

        public MenucategoriesController(WarehouseDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _basePath = Path.Combine(hostEnvironment.WebRootPath, "img/", "menucategories/");
        }

        // GET: Menucategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menucategories.ToListAsync());
        }

        public async Task<IActionResult> Menu()
        {
            List<Menucategory> menucategories = await _context.Menucategories.ToListAsync();

            foreach (Menucategory item in menucategories)
            {
                item.ImagePath = Url.Content("~/img/menucategories/" + item.ImageName);
            }
            return View(menucategories);
        }

        // GET: Menucategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucategory = await _context.Menucategories
                .FirstOrDefaultAsync(m => m.MenucategoryId == id);
            if (menucategory == null)
            {
                return NotFound();
            }

            menucategory.ImagePath = Url.Content("~/img/menucategories/" + menucategory.ImageName);

            return View(menucategory);
        }

        // GET: Menucategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menucategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, ImageFile")] Menucategory menucategory)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwroot/img/menuCategories
                if (menucategory.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(menucategory.ImageFile.FileName);
                    string extension = Path.GetExtension(menucategory.ImageFile.FileName).ToLower();
                    menucategory.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    menucategory.ImagePath = Path.Combine(_basePath + fileName);

                    using (var fileStream = new FileStream(menucategory.ImagePath, FileMode.Create))
                    {
                        await menucategory.ImageFile.CopyToAsync(fileStream);
                    }
                }

                //Insert record
                _context.Add(menucategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menucategory);
        }

        // GET: Menucategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucategory = await _context.Menucategories.FindAsync(id);
            if (menucategory == null)
            {
                return NotFound();
            }

            return View(menucategory);
        }

        // POST: Menucategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenucategoryId,Name,ImageFile,ImageName")] Menucategory menucategory)
        {
            if (id != menucategory.MenucategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Save image to wwroot/img/menuCategories
                    if (menucategory.ImageFile != null)
                    {
                        menucategory.ImagePath = _basePath + "/" + menucategory.ImageName;
                        FileInfo fi = new FileInfo(menucategory.ImagePath);
                        if (fi.Exists)
                            fi.Delete();

                        string fileName = Path.GetFileNameWithoutExtension(menucategory.ImageFile.FileName);
                        string extension = Path.GetExtension(menucategory.ImageFile.FileName).ToLower();
                        menucategory.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                        menucategory.ImagePath = Path.Combine(_basePath + fileName);

                        using (var fileStream = new FileStream(menucategory.ImagePath, FileMode.Create))
                        {
                            await menucategory.ImageFile.CopyToAsync(fileStream);
                        }
                    }

                    _context.Update(menucategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    menucategory.ImagePath = _basePath + "/" + menucategory.ImageName;
                    FileInfo fi = new FileInfo(menucategory.ImagePath);
                    if (fi.Exists)
                        fi.Delete();

                    if (!MenucategoryExists(menucategory.MenucategoryId))
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
            return View(menucategory);
        }

        // GET: Menucategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menucategory = await _context.Menucategories
                .FirstOrDefaultAsync(m => m.MenucategoryId == id);
            if (menucategory == null)
            {
                return NotFound();
            }

            return View(menucategory);
        }

        // POST: Menucategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menucategory = await _context.Menucategories.FindAsync(id);
            if (menucategory != null)
            {
                menucategory.ImagePath = _basePath + "/" + menucategory.ImageName;
                FileInfo fi = new FileInfo(menucategory.ImagePath);
                if (fi.Exists)
                    fi.Delete();
                _context.Menucategories.Remove(menucategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool MenucategoryExists(int id)
        {
            return _context.Menucategories.Any(e => e.MenucategoryId == id);
        }
    }
}
