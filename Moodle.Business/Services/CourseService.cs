using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moodle.Core.Dtos;
using Moodle.Core.Interfaces.Data.Repositories;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;

namespace Moodle.Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherCourseService _teacherCourseService;

        public CourseService(ICourseRepository courseRepository, ITeacherCourseService teacherCourseService)
        {
            _courseRepository = courseRepository;
            _teacherCourseService = teacherCourseService;
        }

        public async Task<List<CourseDto>> GetCoursesWithAllPropertiesAsync()
        {
            var coursesFromDb = await _courseRepository.GetCoursesWithAllPropertiesAsync();
            var courses = coursesFromDb.Select(c =>
                new CourseDto(c.Id, c.Name, c.Teachers, c.GroupId.GetValueOrDefault(), c.Group)).ToList();
            return courses;
        }

        public async Task<CourseDto> GetCourseWithAllPropertiesByIdAsync(int id)
        {
            var courseFromDb = await _courseRepository.GetCourseWithAllPropertiesByIdAsync(id);
            CourseDto course = new(courseFromDb.Id, courseFromDb.Name, courseFromDb.Teachers,
                courseFromDb.GroupId.GetValueOrDefault(), courseFromDb.Group);
            return course;
        }


        public async Task CreateCourseAsync(CreateCourseDto course)
        {
            Course courseToDb = new() {Name = course.Name, GroupId = course.GroupId};
            courseToDb = await _courseRepository.AddAsync(courseToDb);
            await _courseRepository.UnitOfWork.SaveChangesAsync();
            var teachers = await CreateTeacherCourses(courseToDb.Id, course.TeacherIds);
            courseToDb.Teachers = teachers;
            _courseRepository.Update(courseToDb);
            await _courseRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveCourseAsync(int courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            _courseRepository.Remove(course);
            await _courseRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var coursesFromDb = await _courseRepository.GetAllAsync();
            var courses = coursesFromDb.Select(c => 
                    new CourseDto(c.Id, c.Name, c.Teachers, c.GroupId.GetValueOrDefault(), c.Group)).ToList();
            return courses;
        }

        public async Task UpdateCourse(EditCourseDto newCourse)
        {
            await _teacherCourseService.RemoveRangeInCourseAsync(newCourse.Id);
            _teacherCourseService.AddRange(newCourse.TeacherIds, newCourse.Id);
            var course = await _courseRepository.GetAsync(newCourse.Id);
            course.Name = newCourse.Name;
            course.GroupId = newCourse.GroupId;
            _courseRepository.Update(course);
            await _courseRepository.UnitOfWork.SaveChangesAsync();
        }

        private async Task<List<TeacherCourse>> CreateTeacherCourses(int id, IEnumerable<string> teacherIds)
        {
            List<TeacherCourse> teacherCourses = new();
            foreach (var teacherId in teacherIds)
            {
                TeacherCourse teacherCourse = new() {CourseId = id, TeacherId = teacherId};
                teacherCourses.Add(teacherCourse);
                await _teacherCourseService.CreateTeacherCourse(teacherCourse);
            }

            return teacherCourses;
        }
    }
}