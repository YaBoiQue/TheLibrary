using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQLitePCL;
using System.Security.Cryptography;
using TheWarehouse.Models;

namespace TheWarehouse.Controllers
{
    public class CartController(WarehouseDbContext context, IHttpContextAccessor contx) : Controller
    {
        private readonly WarehouseDbContext _context = context;
        private readonly IHttpContextAccessor _contx = contx;

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

        public IActionResult Clear()
        {
            List<Cartitem> cartitems = [];

            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            return View("Index");
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
            if (cartitems.Exists(c => c.Menuitem.MenuitemId == menuitemid))
            {
                //Adjust quantity in cart
                cartitems.Where(c => c.Menuitem.MenuitemId == menuitemid).First().Quantity += quantity;
            }
            else
            {
                //Convert to Cartitem
                Menuitem? menuitem = await _context.Menuitems.Where(m => m.MenuitemId == menuitemid).FirstOrDefaultAsync();
                if (menuitem == null)
                    return RedirectToAction("Index");

                Cartitem cartitem = new(menuitem, quantity);

                do cartitem.CartId = RandomNumberGenerator.GetInt32(Int32.MaxValue);
                while (cartitems.Exists(c => c.CartId == cartitem.CartId));

                cartitems.Add(cartitem);
            }

            //Update Session
            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            //Redirect
            return RedirectToAction("Index");
        }
        

        /// <summary>
        /// Removes Cartitems with matching Menuitem from Session Cart
        /// </summary>
        /// <param name="menuitem">Menuitem to remove from session cart</param>
        /// <returns></returns>
        public IActionResult RemoveMenuItemFromCart(int menuitemid)
        {
            //Get current list of items in cart
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(_contx.HttpContext.Session.GetString("Cart"));
            cartitems ??= [];

            //Remove instances of item in cart
            cartitems.RemoveAll(c => c.Menuitem.MenuitemId.Equals(menuitemid));

            //Update Session
            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes matching Cartitems from Session Cart
        /// </summary>
        /// <param name="cartitem">Cartitem to remove from session cart</param>
        /// <returns></returns>
        public IActionResult RemoveFromCart(int cartid)
        {
            //Get current list of items in cart
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(_contx.HttpContext.Session.GetString("Cart"));
            cartitems ??= [];

            //Remove instances of item in cart
            cartitems.RemoveAll(c => c.CartId == cartid);

            //Update Session
            _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes matching Cartitems from Session Cart
        /// </summary>
        /// <param name="cartitem">Cartitem to remove from session cart</param>
        /// <returns></returns>
        public IActionResult DecrementItem(int cartid)
        {
            //Get current list of items in cart
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(_contx.HttpContext.Session.GetString("Cart"));
            cartitems ??= [];

            try
            {
                cartitems.Where(c => c.CartId == cartid).FirstOrDefault().Quantity--;
                //Update instances of item in cart
                if (cartitems.Where(c => c.CartId == cartid).FirstOrDefault().Quantity <= 0)
                {
                    RemoveFromCart(cartid);
                    return RedirectToAction("Index");
                }

                //Update Session
                _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));
            }
            catch { }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes matching Cartitems from Session Cart
        /// </summary>
        /// <param name="cartitem">Cartitem to remove from session cart</param>
        /// <returns></returns>
        public IActionResult IncrementItem(int cartid)
        {
            //Get current list of items in cart
            List<Cartitem>? cartitems = JsonConvert.DeserializeObject<List<Cartitem>>(_contx.HttpContext.Session.GetString("Cart"));
            cartitems ??= [];

            try
            {
                //Update instances of item in cart
                ++cartitems.Where(c => c.CartId == cartid).FirstOrDefault().Quantity;

                //Update Session
                _contx.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));
            }
            catch { }

            return RedirectToAction("Index");
        }
    }
}
