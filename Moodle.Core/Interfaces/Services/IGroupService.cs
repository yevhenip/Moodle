using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Core.Dtos;

namespace Moodle.Core.Interfaces.Services
{
    public interface IGroupService
    {
        Task<List<GroupDto>> GetGroupsWithAllPropertiesAsync();
        Task<List<GroupDto>> GetAllAsync();
        Task CreateGroupAsync(CreateGroupDto group);
        public List<string> FindErrors(CheckGroup checkGroup, IEnumerable<GroupDto> groups);
        Task RemoveGroupAsync(int groupId);
        Task<GroupDto> GetGroupWithAllPropertiesByIdAsync(int groupId);
        Task UpdateGroup(GroupDto oldGroup, EditGroupDto newGroup, IEnumerable<string> newStudentIds);
    }
}