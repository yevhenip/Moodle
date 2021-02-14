using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Domain;

namespace Moodle.Core.Interfaces.Data.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        public Task<List<Group>> GetGroupsWithAllPropertiesAsync();
        public Task<Group> GetGroupByName(string name);
        Task<Group> GetGroupWithAllPropertiesByIdAsync(int id);
    }
}