namespace Moodle.Domain
{
    public class ExerciseFile : File
    {
        public int? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}