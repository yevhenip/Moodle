using System.Collections.Generic;

namespace Moodle.Domain
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SectionId { get; set; }
        public Section Section { get; set; }
        public IEnumerable<ExerciseFile> AttachedFiles { get; set; } = new List<ExerciseFile>();
        public IEnumerable<ExerciseStudent> Students { get; set; } = new List<ExerciseStudent>();
        
    }
}