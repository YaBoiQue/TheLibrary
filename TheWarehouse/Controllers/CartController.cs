using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace TheWarehouse.Controllers
{
    public class CartController : Controller
    {
        private readonly WarehouseDbContext _context;

        public CartController(WarehouseDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async IActionResult AddToCart(int MenuitemId)
        {
            if (Session["cart"] == null)
            {
                Menuitem? menuitem = await _context.Menuitems.Where(m => m.MenuItemId == MenuitemId).FirstOrDefaultAsync();
            }

            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart()
        {
            return RedirectToAction("Index");
        }
        public IActionResult 
    }
}
