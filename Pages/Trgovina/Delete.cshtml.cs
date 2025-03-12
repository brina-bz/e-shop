using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpremiSe.Data;
using OpremiSe.Models;

namespace OpremiSe.Pages.Trgovina
{
    public class DeleteModel : PageModel
    {
        private readonly OpremiSe.Data.ApplicationDbContext _context;

        public DeleteModel(OpremiSe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produkti Produkti { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkti = await _context.Produkti.FirstOrDefaultAsync(m => m.Id == id);

            if (produkti == null)
            {
                return NotFound();
            }
            else
            {
                Produkti = produkti;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkti = await _context.Produkti.FindAsync(id);
            if (produkti != null)
            {
                Produkti = produkti;
                _context.Produkti.Remove(Produkti);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
