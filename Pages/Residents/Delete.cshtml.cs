using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CanvassHelp.Data;
using CanvassHelp.Models;

namespace CanvassHelp.Pages.Residents
{
    public class DeleteModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public DeleteModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Resident Resident { get; set; }

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
            else 
            {
                Resident = resident;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Residents == null)
            {
                return NotFound();
            }
            var resident = await _context.Residents.FindAsync(id);

            if (resident != null)
            {
                Resident = resident;
                _context.Residents.Remove(Resident);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
