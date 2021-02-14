using System.Collections.Generic;

namespace Moodle.Core.Dtos
{
    public record CreateCourseDto(string Name, int GroupId, IEnumerable<string> TeacherIds)
    {
    }
}