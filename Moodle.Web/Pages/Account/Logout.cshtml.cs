using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moodle.Domain;

namespace Moodle.Web.Pages.Account
{
    [Authorize]
    public class Logout : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public Logout(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/account/login");
        }
    }
}