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
        private readonly UserManager _userManager;
        public EditProfileModel(UserManager userManager)
        {
            _userManager = userManager;
        }
        public User user { get; set; }
        [BindProperty]
        public string NewFirstName { get; set; }
        [BindProperty]
        public string NewLastName { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);

                NewFirstName = user.FirstName;
                NewLastName = user.LastName;
                Email = user.Email;

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
             _userManager.UpdateCustomerInfo(user.Email, NewFirstName, NewLastName);
            TempData["SuccessMessage"] = "Profile updated successfully!";

            return RedirectToPage("/Account");
        }
    }
}
