using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CanvassHelp.Data;
using CanvassHelp.Models;

namespace CanvassHelp.Pages.Groupings
{
    public class CreateModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public CreateModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grouping Grouping { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Groupings == null || Grouping == null)
            {
                return Page();
            }

            _context.Groupings.Add(Grouping);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
