using System.Collections.Generic;
using Moodle.Domain;

namespace Moodle.Core.Dtos
{
    public record CourseDto(int Id, string Name, IEnumerable<TeacherCourse> Teachers, int GroupId, Group Group)
    {
    }
}