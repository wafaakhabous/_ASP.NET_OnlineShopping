using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelAsp1.Models;
using ModelAsp1.Extensions;

namespace ModelAsp1.Pages.Products
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }

        public void OnGet()
        {
            ShoppingCart cart = HttpContext.Session.Get<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
            CartItems = cart.Items;
        }
    }
}
