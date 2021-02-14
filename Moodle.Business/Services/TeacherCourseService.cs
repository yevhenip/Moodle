using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moodle.Core.Interfaces.Data.Repositories;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;

namespace Moodle.Business.Services
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly ITeacherCourseRepository _teacherCourseRepository;

        public TeacherCourseService(ITeacherCourseRepository teacherCourseRepository)
        {
            _teacherCourseRepository = teacherCourseRepository;
        }

        public async Task CreateTeacherCourse(TeacherCourse teacherCourse)
        {
            await _teacherCourseRepository.AddAsync(teacherCourse);
        }

        public void AddRange(IEnumerable<string> teacherIds, int courseId)
        {
            foreach (var teacherId in teacherIds)
            {
                _teacherCourseRepository.Add(new TeacherCourse {CourseId = courseId, TeacherId = teacherId});
            }
        }

        public async Task RemoveRangeInCourseAsync(int courseId)
        {
            var teacherCourses = (await _teacherCourseRepository.GetAllAsync())
                .Where(tc => tc.CourseId == courseId).ToList();
            _teacherCourseRepository.RemoveRange(teacherCourses);
        }
    }
}