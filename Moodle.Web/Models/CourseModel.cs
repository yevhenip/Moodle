using System.Collections.Generic;

namespace Moodle.Web.Models
{
    public record CourseModel(string Name, IEnumerable<string> TeacherIds, int GroupId)
    {
    }
}