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

namespace CanvassHelp.Pages.Addresses
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

        public string StreetSort { get; set; }
        public string IDSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Address> Address { get; set; }

        public async Task OnGetAsync(string sortOrder,
        string currentFilter, string searchString, int? pageIndex)
        {
            if (_context.Addresses != null)
            {
                Address = await _context.Addresses
                .Include(a => a.Grouping).ToListAsync();
            }

            CurrentSort = sortOrder;
            StreetSort = String.IsNullOrEmpty(sortOrder) ? "street_desc" : "";
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

            IQueryable<Address> addressesIQ = from s in _context.Addresses
                                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                addressesIQ = addressesIQ.Where(s => s.StreetName.Contains(searchString)
                                       || s.Postcode.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "street_desc":
                    addressesIQ = addressesIQ.OrderByDescending(s => s.StreetName);
                    break;
                case "ID":
                    addressesIQ = addressesIQ.OrderBy(s => s.AddressId);
                    break;
                case "ID_desc":
                    addressesIQ = addressesIQ.OrderByDescending(s => s.AddressId);
                    break;
                default:
                    addressesIQ = addressesIQ.OrderBy(s => s.StreetName);
                    break;
            }
        }
    }
}