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
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            UserType userType = UserType.CUSTOMER;
            userManager.AddUser(FirstName, LastName, Email, Password, userType);

            return RedirectToPage("Login");
        }
        


    }
}
