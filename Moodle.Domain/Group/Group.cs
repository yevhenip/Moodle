using System.Collections.Generic;

namespace Moodle.Domain
{
    public class Group
    {
        public int Id { get; set; }
        public int Class { get; set; }
        public string Name { get; set; }
        public string SuperVisorId { get; set; }
        public Teacher SuperVisor { get; set; }
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
        public string HeadManId { get; set; }
        public Student HeadMan { get; set; }
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
    }
}