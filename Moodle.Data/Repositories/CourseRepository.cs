using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moodle.Core.Interfaces.Data.Repositories;
using Moodle.Domain;

namespace Moodle.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Course>> GetCoursesWithAllPropertiesAsync()
        {
            return Context.Set<Course>()
                .Include(c => c.Group)
                .Include(t => t.Teachers)
                .ThenInclude(t => t.Teacher).ToListAsync();
        }

        public Task<Course> GetCourseWithAllPropertiesByIdAsync(int id)
        {
            return Context.Set<Course>()
                .Include(c => c.Group)
                .Include(t => t.Teachers)
                .ThenInclude(t => t.Teacher)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}