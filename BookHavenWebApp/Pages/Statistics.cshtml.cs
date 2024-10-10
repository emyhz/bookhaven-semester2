using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class StatisticsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
