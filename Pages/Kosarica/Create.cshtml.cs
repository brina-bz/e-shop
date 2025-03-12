using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpremiSe.Data;
using OpremiSe.Models;

namespace OpremiSe.Pages.Kosarica
{
    public class CreateModel : PageModel
    {
        private readonly OpremiSe.Data.ApplicationDbContext _context;

        public CreateModel(OpremiSe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KosaricaProdukt KosaricaProdukt { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.KosaricaProdukt.Add(KosaricaProdukt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
