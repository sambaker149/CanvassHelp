using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CanvassHelp.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
