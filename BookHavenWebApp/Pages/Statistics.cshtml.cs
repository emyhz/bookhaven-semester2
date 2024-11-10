using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    [Authorize(Policy = "AdminOnly")] //maybe not hardcode this????
    public class StatisticsModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
