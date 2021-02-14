using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Core.Dtos;

namespace Moodle.Core.Interfaces.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetCoursesWithAllPropertiesAsync();
        Task<CourseDto> GetCourseWithAllPropertiesByIdAsync(int id);
        Task CreateCourseAsync(CreateCourseDto course);
        Task RemoveCourseAsync(int courseId);
        Task<List<CourseDto>> GetAllAsync();
        Task UpdateCourse(EditCourseDto newCourse);
    }
}