using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheLivery.Data;
using TheLivery.Models;

namespace TheLivery.Pages.Comenzi
{
    public class CreateModel : PageModel
    {
        private readonly TheLivery.Data.CurieratContext _context;

        public CreateModel(TheLivery.Data.CurieratContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ColetID"] = new SelectList(_context.Set<Colet>(), "ID", "ID");
        ViewData["CurierID"] = new SelectList(_context.Set<Curier>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comenzi.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
