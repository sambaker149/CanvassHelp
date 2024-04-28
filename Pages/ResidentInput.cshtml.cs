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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CanvassHelp.Pages
{
    public class InputModel : PageModel
    {
        private readonly CanvassHelpContext _context;
        private readonly IConfiguration Configuration;

        public InputModel(CanvassHelpContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Resident> Resident { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            if (_context.Residents != null)
            {
                Resident = await _context.Residents
                .Include(r => r.Address).ToListAsync();
            }

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Resident> residentsIQ = from s in _context.Residents
                                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                residentsIQ = residentsIQ.Where(s => s.LastNames.Contains(searchString)
                                       || s.FirstNames.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    residentsIQ = residentsIQ.OrderByDescending(s => s.LastNames);
                    break;
                case "Date":
                    residentsIQ = residentsIQ.OrderBy(s => s.LastContacted);
                    break;
                case "date_desc":
                    residentsIQ = residentsIQ.OrderByDescending(s => s.LastContacted);
                    break;
                default:
                    residentsIQ = residentsIQ.OrderBy(s => s.LastNames);
                    break;
            }
        }
    }
}