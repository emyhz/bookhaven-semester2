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
        private List<Claim> claims;
        public LoginModel(UserManager userManager)
        {
            this.userManager = userManager;
            claims = new List<Claim>();
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
            if(userManager.AuthenticateUser(Email, Password))
            {
                User user = userManager.GetUserByEmail(Email);
                claims.Add(new Claim(ClaimTypes.Name, Email));
                claims.Add(new Claim(ClaimTypes.Role, user.UserType.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
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
