using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class HomeController(ILogger<HomeController> logger, WarehouseDbContext context) : BaseController
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly WarehouseDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            List<Menucategory> categories = await _context.Menucategories.ToListAsync();

            foreach (var category in categories)
            {
                category.Menuitems = await _context.Menuitems.Where(m => m.MenucategoryId == category.MenucategoryId).ToListAsync();

                foreach (Menuitem item in category.Menuitems)
                {
                    item.ImagePath = Url.Content("~/img/menuitems/" + item.ImageName);
                }
            }
            return View(categories);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
