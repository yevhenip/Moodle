using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moodle.Core.Interfaces.Data.Repositiries;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;

namespace Moodle.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public Task<List<Teacher>> GetFreeTeachers()
        {
            return _userRepository.GetFreeTeachers();
        }

        public Task<List<Student>> GetFreeStudents()
        {
            return _userRepository.GetFreeStudents();
        }

        public async Task DeleteUser(string userId, List<User> users)
        {
            var user = await _userManager.FindByIdAsync(userId);

            users.RemoveAll(u => u.Id == userId);

            var claims = await _userManager.GetClaimsAsync(user);
            await _userManager.RemoveClaimsAsync(user, claims);

            await _userManager.DeleteAsync(user);
        }

        public bool IsUserNameExists(string userName, IEnumerable<User> users)
        {
            return users.SingleOrDefault(u => u.UserName == userName) is not null;
        }
    }
}