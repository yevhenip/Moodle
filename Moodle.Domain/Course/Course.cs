using System.Collections.Generic;

namespace Moodle.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TeacherCourse> Teachers { get; set; } = new List<TeacherCourse>();
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public IEnumerable<Section> Sections { get; set; } = new List<Section>();
    }
}   