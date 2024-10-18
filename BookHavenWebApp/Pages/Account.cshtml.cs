using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookHavenWebApp.Pages
{
    public class AccountModel : PageModel
    {
        UserManager _userManager;
        OrderManager _orderManager;
        public AccountModel(UserManager userManager, OrderManager orderManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
        }

        public User user { get; set; }
        public List<Order> orders { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult OnPostPasswordChange()
        {
            user = _userManager.GetUserByEmail(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string result = _userManager.UpdatePassword(user.Email, CurrentPassword, NewPassword, ConfirmPassword);

            // Check the result of the password update operation
            if (result != "Password updated successfully.")
            {
                // Depending on the result, add the appropriate ModelState error
                if (result == "Please fill in all fields.")
                {
                    ModelState.AddModelError("ConfirmNewPassword", "Missing required fields.");
                }
                else if (result == "The new passwords do not match.")
                {
                    ModelState.AddModelError("ConfirmNewPassword", "Your new password does not match. Please try again.");
                }
                else if (result == "The old password is incorrect.")
                {
                    ModelState.AddModelError("CurrentPassword", "Password is incorrect. Please try again.");
                }

                // If there's an error, return the same page with validation messages
                return Page();
            }

            // If the password update was successful, show a success message
            TempData["SuccessMessage"] = "Password changed successfully!";
            return RedirectToPage();

        }
        public IActionResult OnPostDeleteAccount()
        {
            user = _userManager.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                _userManager.DeleteEmployee(user.Email);  // Calls the logic layer to delete the user
                TempData["SuccessMessage"] = "Your account has been deleted.";

                // After account deletion, log the user out and redirect to the homepage or a confirmation page
                HttpContext.SignOutAsync();
                return RedirectToPage("/Login");
            }

            TempData["ErrorMessage"] = "Account not found.";
            return RedirectToPage("/Account");
        }
    }
}
