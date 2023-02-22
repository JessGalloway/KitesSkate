using KitsSkate.DATA.EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using KitesSkate.UI.MVC.Models;
using Newtonsoft.Json;

namespace KitesSkate.UI.MVC.Controllers
{
    public class ShoppingCartController1 : Controller
    {

        /*
 * 1) Register Session in program.cs (builder.Services.AddSession... && app.UseSession())
 * 2) Create the CartItemViewModel class in [ProjName].UI.MVC/Models folder
 * 3) Add the 'Add To Cart' button in the Index and/or Details view of your Products
 * 4) Create the ShoppingCartController (empty controller -> named ShoppingCartController)
 *      - add using statements
 *          - using GadgetStore.DATA.EF.Models;
 *          - using Microsoft.AspNetCore.Identity;
 *          - using GadgetStore.UI.MVC.Models;
 *          - using Newtonsoft.Json;
 *      - Add props for the GadgetStoreContext && UserManager
 *      - Create a constructor for the controller - assign values to context && usermanager
 *      - Code the AddToCart() action
 *      - Code the Index() action
 *      - Code the Index View
 *          - Start with the basic table structure
 *          - Show the items that are easily accessible (like the properties from the model)
 *          - Calculate/show the lineTotal
 *          - Add the RemoveFromCart <a>
 *      - Code the RemoveFromCart() action
 *          - verify the button for RemoveFromCart in the Index view is coded with the controller/action/id
 *      - Add UpdateCart <form> to the Index View
 *      - Code the UpdateCart() action
 *      - Add Submit Order button to Index View
 *      - Code SubmitOrder() action
 * */



        private readonly KitesSkateContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController1(KitesSkateContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
       
        public IActionResult Index()
        {
            //Add the index Action

            //Retrive the Contents from session, convert to C#, then pass that collection back to the view. This is after working in the AddToCart() action

            //retrive the session cart
            var sessionCart = HttpContext.Session.GetString("cart");

            //create the local cart instance 
            Dictionary<int, CartItemViewModel> localCart = null;

            if (sessionCart == null || sessionCart.Count() == 0)//menaing cart exist but there is nothing in it
            {
                ViewBag.Message = "There are no items in your cart.";

                localCart = new Dictionary<int, CartItemViewModel>();
            }
            else
            {
                ViewBag.Message = null;
                localCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
            }

            //pass back localCart so that we can display the content in a strongly typed view
            return View(localCart);
        }

        public IActionResult AddToCart(int id) 
        {

            //Get the cart ready
            //We will have 2 "instances" of the cart - a local collection for the shopping car that we can manipulate, the session version of the cart that is overwriteen if when the carts contents chagne
            //The local instance will handle the C# instance of the cart items 
            //The session instance will handle the JSON instances of cart items
            //session can only store strings or ints so we have to convert them to strings 

            //Local cart instance
            Dictionary<int, CartItemViewModel> localCart = null;

            // retrieve the session instance of the car to see if it exists
            var sessionCart = HttpContext.Session.GetString("cart");

            if (sessionCart == null)
            {

                localCart = new Dictionary<int, CartItemViewModel>();

            }
            else
            {

                localCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            }

            // Retrive the product for the car from the DB
            Gear product = _context.Gears.Find(id);

            //Create a CartItemViewModel for the product being added 
            CartItemViewModel civm = new CartItemViewModel(1, product);

            // If the product was already in the car, increase the qty by 1 
            //Otherwise, add the new item into the localCart

            if (localCart.ContainsKey(product.GearId))
            {
                localCart[product.GearId].Qty++;
            }
            else
            {
                localCart.Add(product.GearId, civm);
            }

            // upodate the session version of the car
            //take the local copy, serialize it , aka tranform to a Json, and then store htat in session
            string jsonCart = JsonConvert.SerializeObject(localCart);

            HttpContext.Session.SetString("cart", jsonCart);

            return RedirectToAction("Index");
        }

    }//end class
}//end namespace
