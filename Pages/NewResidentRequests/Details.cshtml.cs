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

namespace CanvassHelp.Pages.NewResidentRequests
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public DetailsModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

      public NewResidentRequest NewResidentRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ResidentRequests == null)
            {
                return NotFound();
            }

            var request = await _context.ResidentRequests.FirstOrDefaultAsync(m => m.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }
            else 
            {
                NewResidentRequest = request;
            }
            return Page();
        }
    }
}