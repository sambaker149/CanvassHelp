using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CanvassHelp.Data;
using CanvassHelp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CanvassHelp.Pages.NewResidentRequests
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public CreateModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            return Page();
        }

        [BindProperty]
        public NewResidentRequest NewResidentRequest { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ResidentRequests.Add(NewResidentRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}