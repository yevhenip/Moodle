using System.Collections.Generic;

namespace Moodle.Web.Models
{
    public record ModelGroup(string Name, int Class, string SuperVisorId, string HeadManId,
        IEnumerable<string> StudentIds)
    {
    }
}