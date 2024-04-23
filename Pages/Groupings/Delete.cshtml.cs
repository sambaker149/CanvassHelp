using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CanvassHelp.Data;
using CanvassHelp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CanvassHelp.Pages.Groupings
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public DeleteModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Grouping Grouping { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groupings == null)
            {
                return NotFound();
            }

            var grouping = await _context.Groupings.FirstOrDefaultAsync(m => m.GroupingId == id);

            if (grouping == null)
            {
                return NotFound();
            }
            else 
            {
                Grouping = grouping;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Groupings == null)
            {
                return NotFound();
            }
            var grouping = await _context.Groupings.FindAsync(id);

            if (grouping != null)
            {
                Grouping = grouping;
                _context.Groupings.Remove(Grouping);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
