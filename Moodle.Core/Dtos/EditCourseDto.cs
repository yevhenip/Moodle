using System.Collections.Generic;

namespace Moodle.Core.Dtos
{
    public record EditCourseDto(int Id, string Name, IEnumerable<string> TeacherIds, int GroupId)
    {
    }
}