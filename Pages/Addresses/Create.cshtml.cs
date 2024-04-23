using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CanvassHelp.Data;
using CanvassHelp.Models;

namespace CanvassHelp.Pages.Addresses
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
        ViewData["GroupingId"] = new SelectList(_context.Groupings, "GroupingId", "GroupingId");
            return Page();
        }

        [BindProperty]
        public Address Address { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Addresses.Add(Address);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
