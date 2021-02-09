using System.Collections.Generic;

namespace Moodle.Core.Dtos
{
    public record CheckGroup(string Name, string SuperVisorId, string HeadManId, IEnumerable<string> StudentIds,
        bool IsCreated = false)
    {
    }
}