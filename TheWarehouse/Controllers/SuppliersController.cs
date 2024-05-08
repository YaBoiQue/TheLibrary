using Microsoft.Extensions.Hosting;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class SuppliersController : BaseController
    {
        private readonly WarehouseDbContext _context;
        private readonly string _basePath;

        public SuppliersController(WarehouseDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _basePath = Path.Combine(hostEnvironment.WebRootPath, "img/", "suppliers/");
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            List<Supplier> suppliers = await _context.Suppliers.ToListAsync();

            foreach (Supplier item in suppliers)
            {
                item.ImagePath = Url.Content("~/img/suppliers/" + item.ImageName);
            }

            return View(suppliers);
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            supplier.ImagePath = Url.Content("~/img/suppliers/" + supplier.ImageName);

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            Supplier supplier = new();


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            supplier.CreatedUserId = userId;
            supplier.UpdatedUserId = userId;

            return View(supplier);
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,Name,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId,ImageFile")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwroot/img/menuCategories
                if (supplier.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(supplier.ImageFile.FileName);
                    string extension = Path.GetExtension(supplier.ImageFile.FileName).ToLower();
                    supplier.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    supplier.ImagePath = Path.Combine(_basePath + fileName);

                    using (var fileStream = new FileStream(supplier.ImagePath, FileMode.Create))
                    {
                        await supplier.ImageFile.CopyToAsync(fileStream);
                    }
                }

                supplier.CreatedTs = DateTime.UtcNow;
                supplier.UpdatedTs = DateTime.UtcNow;

                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,Name,CreatedTs,UpdatedTs,CreatedUserId,UpdatedUserId,ImageFile,ImageName")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Save image to wwroot/img/suppliers
                    if (supplier.ImageFile != null)
                    {
                        supplier.ImagePath = _basePath + "/" + supplier.ImageName;
                        FileInfo fi = new FileInfo(supplier.ImagePath);
                        if (fi.Exists)
                            fi.Delete();

                        string fileName = Path.GetFileNameWithoutExtension(supplier.ImageFile.FileName);
                        string extension = Path.GetExtension(supplier.ImageFile.FileName).ToLower();
                        supplier.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                        supplier.ImagePath = Path.Combine(_basePath + fileName);

                        using (var fileStream = new FileStream(supplier.ImagePath, FileMode.Create))
                        {
                            await supplier.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    supplier.ImagePath = _basePath + "/" + supplier.ImageName;
                    FileInfo fi = new FileInfo(supplier.ImagePath);
                    if (fi.Exists)
                        fi.Delete();

                    if (!SupplierExists(supplier.SupplierId))
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
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                supplier.ImagePath = _basePath + "/" + supplier.ImageName;
                FileInfo fi = new FileInfo(supplier.ImagePath);
                if (fi.Exists)
                    fi.Delete();
                _context.Suppliers.Remove(supplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}
