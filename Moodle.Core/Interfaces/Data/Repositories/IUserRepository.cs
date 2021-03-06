﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Moodle.Domain;

namespace Moodle.Core.Interfaces.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<Teacher>> GetFreeTeachers();
        public Task<List<Student>> GetFreeStudents();
    }
}