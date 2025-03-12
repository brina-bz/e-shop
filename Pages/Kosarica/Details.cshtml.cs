using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Data;
using OpremiSe.Models;

namespace OpremiSe.Pages.Kosarica
{
    public class DetailsModel : PageModel
    {
        private readonly OpremiSe.Data.ApplicationDbContext _context;

        public DetailsModel(OpremiSe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public KosaricaProdukt KosaricaProdukt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kosaricaprodukt = await _context.KosaricaProdukt.FirstOrDefaultAsync(m => m.Id == id);
            if (kosaricaprodukt == null)
            {
                return NotFound();
            }
            else
            {
                KosaricaProdukt = kosaricaprodukt;
            }
            return Page();
        }
    }
}
