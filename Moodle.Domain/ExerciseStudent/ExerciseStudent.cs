using System;
using System.Collections.Generic;

namespace Moodle.Domain
{
    public class ExerciseStudent
    {
        public int Id { get; set; }
        public double Mark { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletionTime { get; set; }
        public int CurrentAttempt { get; set; }
        public IEnumerable<StudentsExerciseFile> AttachedFiles { get; set; } = new List<StudentsExerciseFile>();
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}