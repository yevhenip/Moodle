namespace Moodle.Domain
{
    public class StudentsExerciseFile : File
    {
        public int? ExerciseStudentId { get; set; }
        public ExerciseStudent ExerciseStudent { get; set; }
    }
}