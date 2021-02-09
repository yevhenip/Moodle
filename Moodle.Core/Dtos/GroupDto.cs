using System.Collections.Generic;
using Moodle.Domain;

namespace Moodle.Core.Dtos
{
    public record GroupDto(int Id, string Name, int Class, Teacher SuperVisor, string HeadManId, IEnumerable<Student> Students)
    {
    }
}