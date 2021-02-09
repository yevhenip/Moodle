using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Domain;

namespace Moodle.Core.Interfaces.Services
{
    public interface IUserService
    {
        public Task<List<Teacher>> GetFreeTeachers();
        public Task<List<Student>> GetFreeStudents();
        public Task DeleteUser(string userId, List<User> users);
        public bool IsUserNameExists(string userName, IEnumerable<User> users);
    }
}