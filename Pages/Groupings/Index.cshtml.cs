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
    public class IndexModel : PageModel
    {
        private readonly CanvassHelpContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(CanvassHelpContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string IDSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Grouping> Grouping { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            if (_context.Groupings != null)
            {
                Grouping = await _context.Groupings.ToListAsync();
            }

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IDSort = sortOrder == "ID" ? "ID_desc" : "ID";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Grouping> groupingIQ = from s in _context.Groupings
                                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                groupingIQ = groupingIQ.Where(s => s.GroupingName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    groupingIQ = groupingIQ.OrderByDescending(s => s.GroupingName);
                    break;
                case "ID":
                    groupingIQ = groupingIQ.OrderBy(s => s.GroupingId);
                    break;
                case "ID_desc":
                    groupingIQ = groupingIQ.OrderByDescending(s => s.GroupingId);
                    break;
                default:
                    groupingIQ = groupingIQ.OrderBy(s => s.GroupingName);
                    break;
            }
        }
    }
}