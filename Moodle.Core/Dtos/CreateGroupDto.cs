using System.Collections.Generic;

namespace Moodle.Core.Dtos
{
    public record CreateGroupDto(string Name, int Class, string SuperVisorId, string HeadManId,
        IEnumerable<string> StudentIds)
    {
        
    }
}