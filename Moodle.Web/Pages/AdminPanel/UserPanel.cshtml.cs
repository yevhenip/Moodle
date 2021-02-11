using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;
using Moodle.Web.Helpers;
using Moodle.Web.Models;

namespace Moodle.Web.Pages.AdminPanel
{
    [Authorize(Policy = "OnlyForAdmin")]
    public class UserPanel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public List<SelectListItem> Items { get; init; } = new()
        {
            new() {Value = "Student", Text = "Student"},
            new() {Value = "Teacher", Text = "Teacher"},
            new() {Value = "Admin", Text = "Admin"}
        };

        public List<User> Users { get; private set; }

        [BindProperty]
        public CreateUserModel CreateUserModel { get; init; }

        public UserPanel(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
            TempData.Set("Users", Users);
        }

        public async Task<IActionResult> OnPostDeleteAsync(string userId)
        {
            Users = TempData.Get<List<User>>("Users");

            await _userService.DeleteUser(userId, Users);
            ModelState.Clear();
            return Page();
        }

        public async Task<IActionResult> OnPostAssignAsync(string userId)
        {
            Users = TempData.Get<List<User>>("Users");
            var role = Request.Form["role"].ToString();
            Users.Single(u => u.Id == userId).UserType = role;
            var user = await _userManager.FindByIdAsync(userId);
            if (user is Student student)
            {
                student.GroupId = null;
            }

            user.UserType = role;
            await _userManager.UpdateAsync(user);
            ModelState.Clear();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            Users = TempData.Get<List<User>>("Users");
            TempData.Set("Users", Users);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_userService.IsUserNameExists(CreateUserModel.UserName, Users))
            {
                ModelState.AddModelError(string.Empty, "User with such user name already exists");
                return Page();
            }

            User user = new()
            {
                FullName = CreateUserModel.FullName,
                UserName = CreateUserModel.UserName,
                PhoneNumber = CreateUserModel.Phone,
                Email = CreateUserModel.Email,
                BirthDate = CreateUserModel.BirthDate,
                UserType = CreateUserModel.UserType,
                PhotoPass = @"/images/defaultUserPhoto.png"
            };
            var result = await _userManager.CreateAsync(user, CreateUserModel.Password);
            if (result.Succeeded)
            {
                await InitializeClaims(user);
                Users.Add(user);
                TempData.Set("Users", Users);
                return Page();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }

        private async Task InitializeClaims(User user)
        {
            if (user.UserType == Items[1].Value)
            {
                await _userManager.AddClaimAsync(user, new Claim("IsTeacher", "True"));
            }

            if (user.UserType == Items[2].Value)
            {
                await _userManager.AddClaimAsync(user, new Claim("IsAdmin", "True"));
            }
        }
    }
}