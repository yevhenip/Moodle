namespace Moodle.Domain
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}