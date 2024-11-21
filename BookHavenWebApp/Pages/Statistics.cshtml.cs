using LogicLayer.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    [Authorize(Policy = "AdminOnly")] 
    public class StatisticsModel : PageModel
    {
        private readonly UserManager _userManager;

        public StatisticsModel(UserManager userManager)
        {
            _userManager = userManager;
        }
        
        public int ClientCount { get; set; }

        public void OnGet()
        {
            var employee = _userManager.GetCustomers();
            ClientCount = employee.Count;

        }
    }
}
