using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moodle.Core.Dtos;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;
using Moodle.Web.Helpers;
using Moodle.Web.Models;

namespace Moodle.Web.Pages.AdminPanel
{
    [Authorize("OnlyForAdmin")]
    public class CoursePanel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly IGroupService _groupService;
        private readonly UserManager<User> _userManager;

        public List<CourseDto> Courses { get; set; }

        public List<SelectListItem> Groups { get; set; } = new();
        public List<SelectListItem> Teachers { get; set; } = new();

        [BindProperty]
        public CourseModel Course { get; init; }

        public CoursePanel(ICourseService courseService, IGroupService groupService, UserManager<User> userManager)
        {
            _courseService = courseService;
            _groupService = groupService;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            TempData.Clear();
            Courses = await _courseService.GetCoursesWithAllPropertiesAsync();
            var groups = await _groupService.GetAllAsync();
            var teachers = await _userManager.Users.OfType<Teacher>().ToListAsync();
            Groups = groups.Select(g => new SelectListItem(g.Name, g.Id.ToString())).ToList();
            Teachers = teachers.Select(t => new SelectListItem(t.FullName, t.Id)).ToList();
            InitializeTempData();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            InitializeFromTempData();
            var coursesToCheck = Courses.Where(c => c.GroupId == Course.GroupId).ToList();
            if (coursesToCheck.Any(c => c.Name == Course.Name))
            {
                ModelState.AddModelError(string.Empty, "You cannot create duplicated course");
                InitializeTempData();
                return Page();
            }

            CreateCourseDto course = new(Course.Name, Course.GroupId, Course.TeacherIds);
            await _courseService.CreateCourseAsync(course);
            TempData.Clear();
            return Redirect("/adminPanel/coursePanel");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int courseId)
        {
            await _courseService.RemoveCourseAsync(courseId);
            return Redirect("/adminPanel/coursePanel");
        }

        public IActionResult OnPostEditAsync(int courseId)
        {
            return Redirect($"/EditCourse/{courseId}");
        }

        private void InitializeTempData()
        {
            TempData.Set("Courses", Courses);
            TempData.Set("Groups", Groups);
            TempData.Set("Teachers", Teachers);
        }

        private void InitializeFromTempData()
        {
            Courses = TempData.Get<List<CourseDto>>("Courses");
            Groups = TempData.Get<List<SelectListItem>>("Groups");
            Teachers = TempData.Get<List<SelectListItem>>("Teachers");
        }
    }
}