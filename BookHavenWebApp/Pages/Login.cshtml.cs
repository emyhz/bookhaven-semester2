using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using LogicLayer.EntityClasses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BookHavenWebApp.Pages
{
    public class LoginModel : PageModel
    {
        public readonly UserManager userManager;
        public LoginModel(UserManager userManager)
        {
            this.userManager = userManager;
        }
        //properties
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password  is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(userManager.AuthenticateUser(Email, Password))
            {

                User user = userManager.GetUserByEmail(Email);


                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Email),  // User's email (to identify)
                new Claim(ClaimTypes.Role, user.UserType.ToString()) // User's role (for authorization)
            };

                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // claims and cookie based authentication
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity); //manage user identity across requests

                // logs in user, sends to browser, used in requests to authenticate
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                Response.Redirect("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return Page();
        }
    }
}
