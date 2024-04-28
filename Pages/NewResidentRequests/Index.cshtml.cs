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
        private readonly CanvassHelpContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(CanvassHelpContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<NewResidentRequest> NewResidentRequest { get; set; }

        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            if (_context.ResidentRequests != null)
            {
                NewResidentRequest = await _context.ResidentRequests
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

            IQueryable<NewResidentRequest> requestsIQ = from s in _context.ResidentRequests
                                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                requestsIQ = requestsIQ.Where(s => s.LastNames.Contains(searchString)
                                       || s.FirstNames.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    requestsIQ = requestsIQ.OrderByDescending(s => s.LastNames);
                    break;
                case "Date":
                    requestsIQ = requestsIQ.OrderBy(s => s.LastContacted);
                    break;
                case "date_desc":
                    requestsIQ = requestsIQ.OrderByDescending(s => s.LastContacted);
                    break;
                default:
                    requestsIQ = requestsIQ.OrderBy(s => s.LastNames);
                    break;
            }
        }
    }
}