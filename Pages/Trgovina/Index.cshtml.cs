using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Data;
using OpremiSe.Models;
using OpremiSe.Helpers;

namespace OpremiSe.Pages.Trgovina
{
    public class IndexModel : PageModel
    {
        private readonly OpremiSe.Data.ApplicationDbContext _context;

        public IndexModel(OpremiSe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Produkti> Produkti { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Kategorije { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? KategorijeOpreme { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Produkti
                                            orderby m.Kategorija
                                            select m.Kategorija;
            var produkti = from p in _context.Produkti
                           select p;

            if (!string.IsNullOrEmpty(SearchString))
            {
                produkti = produkti.Where(s => s.Naziv.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(KategorijeOpreme))
            {
                produkti = produkti.Where(x => x.Kategorija == KategorijeOpreme);
            }
            Kategorije = new SelectList(await genreQuery.Distinct().ToListAsync());

            Produkti = await _context.Produkti.ToListAsync();

            if (Produkti == null || !Produkti.Any())
            {
                Console.WriteLine("No products found.");
            }
        }


        public IActionResult OnPostAddToCart(int productId, int quantity)
        {
            var product = _context.Produkti.Find(productId);

            var cart = HttpContext.Session.GetCart("Cart");
            cart.AddItem(productId, product.Naziv, product.Cena, quantity);
            HttpContext.Session.SetCart("Cart", cart);

            return RedirectToPage();  // Reload page to reflect the changes
        }
    }
}
