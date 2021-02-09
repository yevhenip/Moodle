using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moodle.Core.Dtos;
using Moodle.Core.Interfaces.Services;
using Moodle.Web.Helpers;
using Moodle.Web.Models;

namespace Moodle.Web.Pages.AdminPanel
{
    [Authorize(Policy = "OnlyForAdmin")]
    public class GroupPanel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        [BindProperty]
        public ModelGroup Group { get; init; }

        public List<GroupDto> Groups { get; private set; }
        public List<SelectListItem> Students { get; set; } = new();
        public List<SelectListItem> Teachers { get; set; } = new();

        public GroupPanel(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Groups = await _groupService.GetGroupsWithAllPropertiesAsync();
            var teachers = await _userService.GetFreeTeachers();
            var students = await _userService.GetFreeStudents();

            Teachers.AddRange(teachers.Select(t =>
                new SelectListItem {Text = t.FullName, Value = t.Id}));
            Students.AddRange(students.Select(s =>
                new SelectListItem {Text = s.FullName, Value = s.Id}));

            InitializeTempData();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            InitializeFromTempData();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var errors = InitializeErrors();
            if (errors.Count != 0)
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return Page();
            }

            await AddGroup();

            return Redirect("/adminPanel/groupPanel");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int groupId)
        {
            await _groupService.RemoveGroupAsync(groupId);
            return Redirect("/adminPanel/groupPanel");
        }

        public IActionResult OnPostEditAsync(int groupId)
        {
            return Redirect($"/EditGroup/{groupId}");
        }

        private void InitializeTempData()
        {
            TempData.Set("Groups", Groups);
            TempData.Set("Students", Students);
            TempData.Set("Teachers", Teachers);
        }

        private void InitializeFromTempData()
        {
            Groups = TempData.Get<List<GroupDto>>("Groups");
            Students = TempData.Get<List<SelectListItem>>("Students");
            Teachers = TempData.Get<List<SelectListItem>>("Teachers");
        }

        private List<string> InitializeErrors()
        {
            CheckGroup checkGroup = new(Group.Name, Group.SuperVisorId, Group.HeadManId,
                Group.StudentIds, true);
            return _groupService.FindErrors(checkGroup, Groups);
        }

        private async Task AddGroup()
        {
            CreateGroupDto createGroup = new(Group.Name, Group.Class, Group.SuperVisorId,
                Group.HeadManId, Group.StudentIds);

            await _groupService.CreateGroupAsync(createGroup);
        }
    }
}