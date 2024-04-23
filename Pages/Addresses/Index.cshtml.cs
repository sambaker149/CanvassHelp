using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CanvassHelp.Data;
using CanvassHelp.Models;

namespace CanvassHelp.Pages.Addresses
{
    public class IndexModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public IndexModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Addresses != null)
            {
                Address = await _context.Addresses
                .Include(a => a.Grouping).ToListAsync();
            }
        }
    }
}
