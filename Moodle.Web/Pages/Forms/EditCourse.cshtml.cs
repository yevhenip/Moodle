using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
    public class EditCourse : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly ICourseService _courseService;
        private readonly UserManager<User> _userManager;
        public CourseDto Course { get; set; }

        [BindProperty]
        public CourseModel CourseModel { get; init; }

        public List<SelectListItem> Groups { get; set; } = new();
        public List<SelectListItem> Teachers { get; set; } = new();

        public EditCourse(IGroupService groupService, ICourseService courseService, UserManager<User> userManager)
        {
            _groupService = groupService;
            _courseService = courseService;
            _userManager = userManager;
        }

        public async Task OnGetAsync(int courseId)
        {
            Course = await _courseService.GetCourseWithAllPropertiesByIdAsync(courseId);
            var teachers = _userManager.Users.OfType<Teacher>().ToList();
            var groups = await _groupService.GetAllAsync();
            groups.RemoveAll(g => g.Id == Course.GroupId);
            foreach (var teacher in Course.Teachers)
            {
                teachers.RemoveAll(t => t.Id == teacher.TeacherId);
            }

            InitializeSelect(teachers, groups);
            InitializeTempData();
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            InitializeFromTempData();
            EditCourseDto course = new(Course.Id, CourseModel.Name, CourseModel.TeacherIds, CourseModel.GroupId);
            
            await _courseService.UpdateCourse(course);
            TempData.Clear();
            return Redirect("/adminPanel/coursePanel");
        }

        private void InitializeSelect(IEnumerable<Teacher> teachers, IReadOnlyCollection<GroupDto> groups)
        {
            Teachers.AddRange(teachers.Select(t =>
                new SelectListItem {Text = t.FullName, Value = t.Id}));
            Teachers.AddRange(Course.Teachers.Select(t => new SelectListItem
                {Text = t.Teacher.FullName, Value = t.Teacher.Id, Selected = true}));


            Groups.AddRange(groups.Select(g =>
                new SelectListItem {Text = g.Name, Value = g.Id.ToString()}));
            Groups.Add(new SelectListItem
                {Text = Course.Group.Name, Value = Course.Group.Id.ToString(), Selected = true});
        }

        private void InitializeTempData()
        {
            TempData.Set("Course", Course);
            TempData.Set("Groups", Groups);
            TempData.Set("Teachers", Teachers);
        }

        private void InitializeFromTempData()
        {
            Course = TempData.Get<CourseDto>("Course");
            Groups = TempData.Get<List<SelectListItem>>("Groups");
            Teachers = TempData.Get<List<SelectListItem>>("Teachers");
        }
    }
}