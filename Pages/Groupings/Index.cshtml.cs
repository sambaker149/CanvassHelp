using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CanvassHelp.Data;
using CanvassHelp.Models;

namespace CanvassHelp.Pages.Groupings
{
    public class IndexModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public IndexModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        public IList<Grouping> Grouping { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Groupings != null)
            {
                Grouping = await _context.Groupings.ToListAsync();
            }
        }
    }
}
