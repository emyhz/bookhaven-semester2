using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Emit;

namespace BookHavenWebApp.Pages
{
    public class AccountModel : PageModel
    {
        UserManager _userManager;
        OrderManager _orderManager;
        ReviewManager _reviewManager;
        public AccountModel(UserManager userManager, OrderManager orderManager, ReviewManager reviewManager)
        {
            _userManager = userManager;
            _orderManager = orderManager;
            _reviewManager = reviewManager;
        }

        public User user { get; set; }
        public List<Order> orders { get; set; }
        public List<Review> reviews { get; set; }
        public Order LastUsedAddress { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string Country { get; set; }
        [BindProperty]
        public string ZipCode { get; set; }


        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);
                orders = _orderManager.GetUserOrders(user.Id);
                reviews = _reviewManager.GetReviewsByUser(user.Id);
                LastUsedAddress = _orderManager.GetLastUsedAddress(user.Id);

                if (LastUsedAddress != null)
                {
                    Address = LastUsedAddress.Address;
                    City = LastUsedAddress.City;
                    Country = LastUsedAddress.Country;
                    ZipCode = LastUsedAddress.ZipCode;
                }

                return Page();
            }
            else
            {
                //return NotFound(); old code
                return RedirectToPage("/Login");
            }
        }
        public IActionResult OnPostPasswordChange()
        {
            user = _userManager.GetUserByEmail(User.Identity.Name);
            orders = _orderManager.GetUserOrders(user.Id);
            reviews = _reviewManager.GetReviewsByUser(user.Id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            UpdatePasswordResults results = _userManager.UpdatePassword(user.Email, CurrentPassword, NewPassword, ConfirmPassword);
            if (results != UpdatePasswordResults.PASSWORD_UPDATED)
            {
                switch (results)
                {
                    case UpdatePasswordResults.INVALID_OLD_PASSWORD:
                        ModelState.AddModelError("CurrentPassword", "Incorrect password.");
                        break;
                    case UpdatePasswordResults.PASSWORDS_DONT_MATCH:
                        ModelState.AddModelError("ConfirmPassword", "Passwords do not match.");
                        break;
                    case UpdatePasswordResults.MISSING_FIELDS:
                        ModelState.AddModelError("", "Please fill in all fields.");
                        break;
                }
                return Page();


            }
            TempData["SuccessMessage"] = "Password changed successfully!";
            return RedirectToPage();
        }
        public IActionResult OnPostDeleteAccount()
        {
            user = _userManager.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                _userManager.DeleteUser(user.Email);
                TempData["SuccessMessage"] = "Your account has been deleted.";

                // After account deletion, log the user out and redirect to the homepage or a confirmation page
                HttpContext.SignOutAsync();
                return RedirectToPage("/Login");
            }

            TempData["ErrorMessage"] = "Account not found.";
            return RedirectToPage("/Account");
        }

        public IActionResult OnPostEditReview(int reviewId)
        {
            return RedirectToPage("/EditReview", new { reviewId = reviewId });
        }
        public IActionResult OnPostDeleteReview(int reviewId)
        {
            try
            {
                _reviewManager.DeleteReview(reviewId);
                TempData["SuccessMessage"] = "Review deleted successfully!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to delete the review: {ex.Message}";
                return RedirectToPage();
            }
        }
    }
}
