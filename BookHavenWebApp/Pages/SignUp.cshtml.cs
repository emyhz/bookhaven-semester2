using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer.Managers;
using System.ComponentModel.DataAnnotations;
using LogicLayer.Enums;
using System.Reflection.Metadata.Ecma335;

namespace BookHavenWebApp.Pages
{
    public class SignUpModel : PageModel
    {

        public readonly UserManager userManager; 

        public SignUpModel(UserManager userManager)
        {
            this.userManager = userManager;
        }

        //properties
        [BindProperty]
        [Required(ErrorMessage = "Full name is required."), MinLength(length: 2, ErrorMessage = "Provide a name more than 2 characters ")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password  is required."), MinLength(length: 5, ErrorMessage = "Provide a password with at least 7 characters. ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IActionResult OnPost()
        {
            //if model is invalid
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            UserType userType = UserType.CUSTOMER;
            userManager.AddUser(FirstName, LastName, Email, Password, userType);

            return RedirectToPage("/Login");
        }
    }
}
