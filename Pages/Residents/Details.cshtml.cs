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

namespace CanvassHelp.Pages.Residents
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public DetailsModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

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
    }
}
