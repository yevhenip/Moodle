using System.Collections.Generic;

namespace Moodle.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}