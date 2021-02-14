using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Domain;

namespace Moodle.Core.Interfaces.Data.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<Course>> GetCoursesWithAllPropertiesAsync();
        Task<Course> GetCourseWithAllPropertiesByIdAsync(int id);
    }
}