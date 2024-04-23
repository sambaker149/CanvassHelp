using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CanvassHelp.Data;
using CanvassHelp.Models;

namespace CanvassHelp.Pages
{
    public class ResidentInputModel : PageModel
    {
        private readonly CanvassHelp.Data.CanvassHelpContext _context;

        public ResidentInputModel(CanvassHelp.Data.CanvassHelpContext context)
        {
            _context = context;
        }

        public IList<Resident> Resident { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Residents != null)
            {
                Resident = await _context.Residents
                .Include(r => r.Address).ToListAsync();
            }
        }
    }
}