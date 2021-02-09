using System.Collections.Generic;

namespace Moodle.Domain
{
    public class Teacher : User
    {
        public IEnumerable<TeacherCourse> Courses { get; set; } = new List<TeacherCourse>();
        public Group Group { get; set; }
    }
}
