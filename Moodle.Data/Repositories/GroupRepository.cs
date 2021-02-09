using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moodle.Core.Interfaces.Data.Repositiries;
using Moodle.Domain;

namespace Moodle.Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Group>> GetGroupsWithAllPropertiesAsync()
        {
            return Context.Set<Group>().Include(g => g.SuperVisor)
                .Include(g => g.HeadMan)
                .Include(g => g.Students)
                .Include(g => g.Courses).ToListAsync();
        }

        public Task<Group> GetGroupByName(string name)
        {
            return Context.Set<Group>().SingleOrDefaultAsync(g => g.Name == name);
        }

        public Task<Group> GetGroupWithAllPropertiesByIdAsync(int id)
        {
            return Context.Set<Group>().Include(g => g.SuperVisor)
                .Include(g => g.HeadMan)
                .Include(g => g.Students)
                .Include(g => g.Courses).SingleOrDefaultAsync(g => g.Id == id);
        }
    }
}