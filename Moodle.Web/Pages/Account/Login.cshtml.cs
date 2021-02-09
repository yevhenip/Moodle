using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moodle.Domain;
using Moodle.Web.Models;

namespace Moodle.Web.Pages.Account
{
    public class Login : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public LoginModel LoginModel { get; init; }

        public Login(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(LoginModel.UserName, LoginModel.Password,
                LoginModel.RememberMe, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(LoginModel.UserName);
                var claims = await _userManager.GetClaimsAsync(user);
                HttpContext.Response.Cookies.Append("FilePath", user.PhotoPass);
                ClaimsIdentity id = new (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(id));
                return Redirect("/");
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return Page();
        }
    }
}   