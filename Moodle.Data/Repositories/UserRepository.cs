using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moodle.Core.Interfaces.Data.Repositiries;
using Moodle.Domain;

namespace Moodle.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Teacher>> GetFreeTeachers()
        {
            return Context.Users.OfType<Teacher>()
                .Include(t => t.Group)
                .Where(t => t.Group == null).ToListAsync();
        }

        public Task<List<Student>> GetFreeStudents()
        {
            return Context.Users.OfType<Student>()
                .Where(t => t.GroupId == null).ToListAsync();
        }
    }
}