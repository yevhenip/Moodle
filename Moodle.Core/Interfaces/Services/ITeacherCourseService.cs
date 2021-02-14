using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Domain;

namespace Moodle.Core.Interfaces.Services
{
    public interface ITeacherCourseService
    {
        Task CreateTeacherCourse(TeacherCourse teacherCourse);
        void AddRange(IEnumerable<string> teacherIds, int courseId);
        Task RemoveRangeInCourseAsync(int courseId);
    }
}