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

namespace OpremiSe.Pages.Trgovina
{
    public class EditModel : PageModel
    {
        private readonly OpremiSe.Data.ApplicationDbContext _context;

        public EditModel(OpremiSe.Data.ApplicationDbContext context)
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

            var produkti =  await _context.Produkti.FirstOrDefaultAsync(m => m.Id == id);
            if (produkti == null)
            {
                return NotFound();
            }
            Produkti = produkti;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Produkti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktiExists(Produkti.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProduktiExists(int id)
        {
            return _context.Produkti.Any(e => e.Id == id);
        }
    }
}
