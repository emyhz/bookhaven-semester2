using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookHavenWebApp.Pages
{
    public class EditProfileModel : PageModel
    {
        private readonly UserManager userManager;
        public EditProfileModel(UserManager userManager)
        {
            this.userManager = userManager;
        }
        public User user { get; set; }
        [BindProperty]
        public string NewfirstName { get; set; }
        [BindProperty]
        public string NewlastName { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = userManager.GetUserByEmail(User.Identity.Name);
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userManager.UpdateCustomerInfo(user.Email, NewfirstName, NewlastName);
            TempData["SuccessMessage"] = "Profile updated successfully!";

            return RedirectToPage("/Account");
        }
    }
}
