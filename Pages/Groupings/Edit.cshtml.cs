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

namespace CanvassHelp.Pages.Groupings
{
    public class EditModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public EditModel(CanvassHelp.Data.CanvassHelpContext context)
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

            var grouping =  await _context.Groupings.FirstOrDefaultAsync(m => m.GroupingId == id);
            if (grouping == null)
            {
                return NotFound();
            }
            Grouping = grouping;
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

            _context.Attach(Grouping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupingExists(Grouping.GroupingId))
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

        private bool GroupingExists(int id)
        {
          return (_context.Groupings?.Any(e => e.GroupingId == id)).GetValueOrDefault();
        }
    }
}
