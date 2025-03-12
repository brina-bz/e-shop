using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Data;
using OpremiSe.Models;
using OpremiSe.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace OpremiSe.Pages.Kosarica
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public ShoppingCart Cart { get; set; }

        public void OnGet()
        {
            Cart = HttpContext.Session.GetCart("Cart");
        }

        public IActionResult OnPostAddToCart(int productId, string productName, decimal price, int quantity)
        {
            var cart = HttpContext.Session.GetCart("Cart");
            cart.AddItem(productId, productName, price, quantity);
            HttpContext.Session.SetCart("Cart", cart);

            return RedirectToPage();
        }

        public IActionResult OnPostRemoveFromCart(int productId)
        {
            var cart = HttpContext.Session.GetCart("Cart");
            cart.RemoveItem(productId);
            HttpContext.Session.SetCart("Cart", cart);

            return RedirectToPage();
        }
    }
}

