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
    public class IndexModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public IndexModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        public IList<NewResidentRequest> NewResidentRequests { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ResidentRequests != null)
            {
                NewResidentRequests = await _context.ResidentRequests
                .Include(r => r.Address).ToListAsync();
            }
        }
    }
}