using Microsoft.AspNetCore.Mvc;

namespace TheWarehouse.Controllers
{
    public class SupplyCountController : Controller
    {
        public IActionResult Index()
        {
            List<SupplyCount> supplyCount = [];



            return View();
        }
    }
}
