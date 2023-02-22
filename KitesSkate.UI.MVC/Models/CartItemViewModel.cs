using KitsSkate.DATA.EF.Models;

namespace KitesSkate.UI.MVC.Models
{
    public class CartItemViewModel
    {

        public int Qty { get; set; }

        public Gear Cartprod { get; set; }

        public CartItemViewModel() { }


        public CartItemViewModel(int qty, Gear cartProd)
        {
            Qty = qty;
            Cartprod = cartProd;
        }
    }
}
