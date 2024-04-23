using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanvassHelp.Data;
using CanvassHelp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CanvassHelp.Pages
{
    public class ResidentEditModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public ResidentEditModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resident Resident { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Residents == null)
            {
                return NotFound();
            }

            var resident = await _context.Residents.FirstOrDefaultAsync(m => m.ResidentId == id);
            if (resident == null)
            {
                return NotFound();
            }
            Resident = resident;
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Resident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(Resident.ResidentId))
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

        private bool ResidentExists(int id)
        {
            return _context.Residents.Any(e => e.ResidentId == id);
        }
    }
}