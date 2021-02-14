using Moodle.Core.Interfaces.Data.Repositories;
using Moodle.Domain;

namespace Moodle.Data.Repositories
{
    public class TeacherCourseRepository : Repository<TeacherCourse>, ITeacherCourseRepository
    {
        public TeacherCourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}