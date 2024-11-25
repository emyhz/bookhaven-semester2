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
                orders = _orderManager.GetUserOrders(user.Id);
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

            _userManager.UpdatePassword(user.Email, CurrentPassword, NewPassword, ConfirmPassword);


            TempData["SuccessMessage"] = "Password changed successfully!";
            return RedirectToPage();

        }
        public IActionResult OnPostDeleteAccount()
        {
            user = _userManager.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                _userManager.DeleteEmployee(user.Email);
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
