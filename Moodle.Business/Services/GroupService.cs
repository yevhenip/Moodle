using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moodle.Core.Dtos;
using Moodle.Core.Interfaces.Data.Repositories;
using Moodle.Core.Interfaces.Services;
using Moodle.Domain;

namespace Moodle.Business.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly UserManager<User> _userManager;

        public GroupService(IGroupRepository groupRepository, UserManager<User> userManager)
        {
            _groupRepository = groupRepository;
            _userManager = userManager;
        }

        public async Task<List<GroupDto>> GetGroupsWithAllPropertiesAsync()
        {
            var groupsFromDb = await _groupRepository.GetGroupsWithAllPropertiesAsync();
            var groups = groupsFromDb.Select(gfd =>
                new GroupDto(gfd.Id, gfd.Name, gfd.Class, gfd.SuperVisor, gfd.HeadManId, gfd.Students));
            return groups.ToList();
        }

        public async Task<List<GroupDto>> GetAllAsync()
        {
            var groupsFromDb = await _groupRepository.GetAllAsync();
            var groups = groupsFromDb.Select(g => 
                    new GroupDto(g.Id, g.Name, g.Class, null, g.HeadManId, null))
                .ToList();
            return groups;
        }

        public async Task CreateGroupAsync(CreateGroupDto group)
        {
            var superVisor = await _userManager.FindByIdAsync(group.SuperVisorId) as Teacher;
            var headMan = await _userManager.FindByIdAsync(group.HeadManId) as Student;

            var students = await InitializeStudents(group.StudentIds);

            Group groupToDb = new()
            {
                Name = group.Name,
                Class = group.Class,
                Courses = null,
                SuperVisor = superVisor,
                SuperVisorId = superVisor?.Id,
                Students = students,
                HeadMan = headMan,
                HeadManId = headMan?.Id
            };

            await _groupRepository.AddAsync(groupToDb);
            await _groupRepository.UnitOfWork.SaveChangesAsync();

            var groupId = await GetGroupIdByName(group.Name);
            await UpdateStudentsAsync(groupId, students);
        }

        public List<string> FindErrors(CheckGroup checkGroup, IEnumerable<GroupDto> groups)
        {
            List<string> errors = new();
            if (groups.SingleOrDefault(g => g.Name == checkGroup.Name) is not null)
            {
                errors.Add("Group with such name already exists");
            }

            if (!checkGroup.StudentIds.Contains(checkGroup.HeadManId))
            {
                errors.Add("Students list must contain a headman as well");
            }

            return errors;
        }

        public async Task RemoveGroupAsync(int groupId)
        {
            var groupFoDeletion = await _groupRepository.GetAsync(groupId);
            _groupRepository.Remove(groupFoDeletion);
            await _groupRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<GroupDto> GetGroupWithAllPropertiesByIdAsync(int groupId)
        {
            var groupFromDb = await _groupRepository.GetGroupWithAllPropertiesByIdAsync(groupId);
            GroupDto group = new(
                groupFromDb.Id, groupFromDb.Name, groupFromDb.Class, groupFromDb.SuperVisor,
                groupFromDb.HeadManId, groupFromDb.Students
            );
            return group;
        }

        public async Task UpdateGroup(GroupDto oldGroup, EditGroupDto newGroup, IEnumerable<string> newStudentIds)
        {
            await SetStudentGroupIdsToNullAsync(oldGroup.Students.Select(s => s.Id));
            var students = await InitializeStudents(newStudentIds);
            await UpdateStudentsAsync(oldGroup.Id, students);
            var headMan = students.FirstOrDefault(s => s.Id == newGroup.HeadManId);
            Group group = new()
            {
                Id = newGroup.Id,
                Name = newGroup.Name,
                Class = newGroup.Class,
                Students = students,
                HeadMan = headMan,
                HeadManId = headMan?.Id,
                SuperVisorId = newGroup.SuperVisorId
            };
            _groupRepository.Update(group);
            await _groupRepository.UnitOfWork.SaveChangesAsync();
        }

        private async Task SetStudentGroupIdsToNullAsync(IEnumerable<string> studentIds)
        {
            foreach (var studentId in studentIds)
            {
                var student = await _userManager.FindByIdAsync(studentId) as Student;
                if (student == null) continue;
                student.GroupId = null;
                await _userManager.UpdateAsync(student);
            }
        }

        private async Task UpdateStudentsAsync(int groupId, IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                student.GroupId = groupId;
                await _userManager.UpdateAsync(student);
            }
        }

        private async Task<List<Student>> InitializeStudents(IEnumerable<string> studentIds)
        {
            List<Student> students = new();
            foreach (var id in studentIds)
            {
                var student = await _userManager.FindByIdAsync(id) as Student;
                students.Add(student);
            }

            return students;
        }

        private async Task<int> GetGroupIdByName(string name)
        {
            var group = await _groupRepository.GetGroupByName(name);
            return group.Id;
        }
    }
}