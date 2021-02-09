using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moodle.Core.Dtos;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;
using Moodle.Web.Helpers;
using Moodle.Web.Models;

namespace Moodle.Web.Pages.Forms
{
    [Authorize("OnlyForAdmin")]
    public class EditGroup : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        public GroupDto Group { get; set; }

        [BindProperty]
        public ModelGroup GroupModel { get; init; }

        public List<SelectListItem> Students { get; set; } = new();
        public List<SelectListItem> Teachers { get; set; } = new();
        public List<SelectListItem> StudentsForHeadMan { get; set; } = new();

        public EditGroup(IGroupService groupService, IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        public async Task OnGetAsync(int groupId)
        {
            Group = await _groupService.GetGroupWithAllPropertiesByIdAsync(groupId);
            var teachers = await _userService.GetFreeTeachers();
            var students = await _userService.GetFreeStudents();
            InitializeSelect(teachers, students);
            InitializeTempData();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            InitializeFromTempData();

            var errors = InitializeErrors();
            if (errors.Count != 0)
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return Page();
            }

            EditGroupDto newGroup = new(Group.Id, GroupModel.Name, GroupModel.Class, GroupModel.SuperVisorId,
                GroupModel.HeadManId, GroupModel.StudentIds);

            await _groupService.UpdateGroup(Group, newGroup, GroupModel.StudentIds);
            return Redirect("/adminPanel/groupPanel");
        }

        private void InitializeSelect(IEnumerable<Teacher> teachers, IReadOnlyCollection<Student> students)
        {
            Teachers.AddRange(teachers.Select(t =>
                new SelectListItem {Text = t.FullName, Value = t.Id}));
            Teachers.Add(new SelectListItem
                {Text = Group.SuperVisor.FullName, Value = Group.SuperVisor.Id, Selected = true});

            Students.AddRange(students.Select(s =>
                new SelectListItem {Text = s.FullName, Value = s.Id}));
            StudentsForHeadMan.AddRange(students.Select(s =>
                new SelectListItem {Text = s.FullName, Value = s.Id}));

            foreach (var student in Group.Students)
            {
                Students.Add(new SelectListItem {Text = student.FullName, Value = student.Id, Selected = true});
                if (student.Id == Group.HeadManId)
                {
                    StudentsForHeadMan.Add(new SelectListItem
                        {Text = student.FullName, Value = student.Id, Selected = true});
                }
                else
                {
                    StudentsForHeadMan.Add(new SelectListItem {Text = student.FullName, Value = student.Id});
                }
            }
        }

        private void InitializeTempData()
        {
            TempData.Set("Group", Group);
            TempData.Set("Students", Students);
            TempData.Set("StudentsForHeadMan", StudentsForHeadMan);
            TempData.Set("Teachers", Teachers);
        }

        private void InitializeFromTempData()
        {
            Group = TempData.Get<GroupDto>("Group");
            Students = TempData.Get<List<SelectListItem>>("Students");
            StudentsForHeadMan = TempData.Get<List<SelectListItem>>("StudentsForHeadMan");
            Teachers = TempData.Get<List<SelectListItem>>("Teachers");
        }

        private List<string> InitializeErrors()
        {
            CheckGroup checkGroup = new(GroupModel.Name, GroupModel.SuperVisorId, GroupModel.HeadManId,
                GroupModel.StudentIds);
            return _groupService.FindErrors(checkGroup, new[] {Group});
        }
    }
}