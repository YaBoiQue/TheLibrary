using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQLitePCL;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class CartController : Controller
    {
        private readonly WarehouseDbContext _context;
        private readonly IHttpContextAccessor _contx;

        public CartController(WarehouseDbContext context, IHttpContextAccessor contx)
        {
            _context = context;
            _contx = contx;
        }

        public IActionResult Index()
        {
            List<Cartitem> carts = GetCart();
            CartListVM vm = new();

            foreach (Cartitem item in carts)
            {
                item.Total = item.Quantity * item.Menuitem.Price;
                if (item.Total != null)
                    vm.Total += (decimal)item.Total;
            }

            vm.Cartitems = carts;

            return View(vm);
        }

        /// <summary>
        /// Returns the current list of items in the Session Cart. Will not return null
        /// </summary>
        /// <returns>
        /// A List object of Cartitem objects consisting of the current Session Cart
        /// </returns>
        public List<Cartitem> GetCart()
        {
            //Get current list of items in cart
            String? tempStr = _contx.HttpContext.Session.GetString("Cart");

            if (tempStr == null)
            {
                _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(new List<Cartitem>()));
                tempStr = _contx.HttpContext.Session.GetString("Cart");
            }
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(tempStr);
            cartitems ??= [];

            return cartitems;
        }

        /// <summary>
        /// Adds a cartitem to the Sesson Cart or updates the count if one exists using menuitem and quantity. quantity defaults to 1. 
        /// </summary>
        /// <param name="menuitem">The Menuitem object to be added or updated in the cart</param>
        /// <param name="quantity">The number of Menuitem objects to add</param>
        /// <returns></returns>
        public async Task<IActionResult> AddMenuItemToCart(int menuitemid, int quantity = 1)
        {
            //Convert to Cartitem
            Menuitem? menuitem = await _context.Menuitems.Where(m => m.MenuitemId == menuitemid).FirstOrDefaultAsync();
            if (menuitem == null)
                return RedirectToAction("Index");

            Cartitem cartitem = new(menuitem, quantity);

            //Redirect
            return AddToCart(cartitem);
        }
        
        /// <summary>
        /// Adds a Cartitem to the Session Cart or updates count if one exists
        /// </summary>
        /// <param name="item">The Cartitem to be added or updated in the cart</param>
        /// <returns></returns>
        public IActionResult AddToCart(Cartitem item)
        {
            //Get current list of items in cart
            String? tempStr = _contx.HttpContext.Session.GetString("Cart");
            
            if (tempStr == null)
            {
                _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(new List<Cartitem>()));
                tempStr = _contx.HttpContext.Session.GetString("Cart");
            }
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(tempStr);
            cartitems ??= [];

            //Check if item already in cart
            if (cartitems.Exists(c => c.Menuitem.MenuitemId == item.Menuitem.MenuitemId))
            {
                //Adjust quantity in cart
                cartitems.Where(c => c.Menuitem.MenuitemId == item.Menuitem.MenuitemId).First().Quantity += item.Quantity;
            }else
            {
                cartitems.Add(item);
            }

            //Update Session
            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes matching Cartitems from Session Cart
        /// </summary>
        /// <param name="cartitem">Cartitem to remove from session cart</param>
        /// <returns></returns>
        public IActionResult RemoveFromCart(Cartitem cartitem)
        {
            //Get current list of items in cart
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(_contx.HttpContext.Session.GetString("Cart"));
            cartitems ??= [];

            //Remove instances of item in cart
            cartitems.RemoveAll(c => c.Equals(cartitem));

            //Update Session
            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes Cartitems with matching Menuitem from Session Cart
        /// </summary>
        /// <param name="menuitem">Menuitem to remove from session cart</param>
        /// <returns></returns>
        public IActionResult RemoveMenuItemFromCart(Menuitem menuitem)
        {
            //Get current list of items in cart
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(_contx.HttpContext.Session.GetString("Cart"));
            cartitems ??= [];

            //Remove instances of item in cart
            cartitems.RemoveAll(c => c.Menuitem.MenuitemId.Equals(menuitem.MenuitemId));

            //Update Session
            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            return RedirectToAction("Index");
        }
    }
}
