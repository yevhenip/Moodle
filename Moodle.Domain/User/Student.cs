using System.Collections.Generic;

namespace Moodle.Domain
{
    public class Student : User
    {
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public Group HeadGroup { get; set; }
        public IEnumerable<ExerciseStudent> Exercises { get; set; } = new List<ExerciseStudent>();
    }
}