using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelAsp1.Data;
using ModelAsp1.Models;
using ModelAsp1.Extensions;
namespace ModelAsp1.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ModelAsp1.Data.ModelAsp1Context _context;

        public IndexModel(ModelAsp1.Data.ModelAsp1Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProductGenre { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Product
                                            orderby m.Genre
                                            select m.Genre;


            var products = from m in _context.Product  select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ProductGenre))
            {
                products = products.Where(x => x.Genre == ProductGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Product = await products.ToListAsync();
        }
        public async Task<IActionResult> OnPostAddToCartAsync(int id, int quantity)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)//si produit n'existe pas
            {
                return NotFound();
            }

            ShoppingCart cart = HttpContext.Session.Get<ShoppingCart>("ShoppingCart") ?? new ShoppingCart();
            cart.AddItem(product, quantity);
            HttpContext.Session.Set("ShoppingCart", cart);

            return RedirectToPage("Index");
        }
    }
}
