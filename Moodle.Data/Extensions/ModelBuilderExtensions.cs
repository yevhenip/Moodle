using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moodle.Domain;

namespace Moodle.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        private const string AdminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string Student1Id = "B22618B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string Student2Id = "B22618B9-42A2-4115-9631-1C2D1E2AC5F7";
        private const string TeacherId = "B22628B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string HeadManId = "B22638B8-42A2-4115-9631-1C2D1E2AC5F7";

        private static string PassGenerate(User user)
        {
            var passHash = new PasswordHasher<User>();
            return passHash.HashPassword(user, "paPA123.");
        }

        public static void Seed(this ModelBuilder entity)
        {
            var admin = new User
            {
                Id = AdminId,
                UserName = "masteradmin",
                NormalizedUserName = "MASTERADMIN",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D")
            };
            var teacher = new Teacher
            {
                Id = TeacherId,
                UserName = "masterteacher",
                NormalizedUserName = "MASTERTEACHER",
                Email = "teacher@teacher.com",
                NormalizedEmail = "TEACHER@TEACHER.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D")
            };

            var student1 = new Student
            {
                Id = Student1Id,
                UserName = "student1",
                NormalizedUserName = "STUDENT1",
                Email = "student1@student1.com",
                NormalizedEmail = "STUDENT1@STUDENT1.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D")
            };
            var student2 = new Student
            {
                Id = Student2Id,
                UserName = "student2",
                NormalizedUserName = "STUDENT2",
                Email = "student2@student2.com",
                NormalizedEmail = "STUDENT2@STUDENT2.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D")
            };
            var headman = new Student
            {
                Id = HeadManId,
                UserName = "headman",
                NormalizedUserName = "HEADMAN",
                Email = "headman@headman.com",
                NormalizedEmail = "HEADMAN@HEADMAN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D")
            };

            admin.PasswordHash = PassGenerate(admin);
            teacher.PasswordHash = PassGenerate(teacher);
            student1.PasswordHash = PassGenerate(student1);
            student2.PasswordHash = PassGenerate(student2);
            headman.PasswordHash = PassGenerate(headman);

            entity.Entity<User>().HasData(admin);
            entity.Entity<Teacher>().HasData(teacher);
            entity.Entity<Student>().HasData(student1);
            entity.Entity<Student>().HasData(student2);
            entity.Entity<Student>().HasData(headman);

            Group group = new()
            {
                Id = 1,
                Class = 2,
                SuperVisorId = TeacherId,
                HeadManId = HeadManId,
                Name = "208"
            };

            entity.Entity<Group>().HasData(group);
            
            entity.Entity<ExerciseFile>().HasData(
                new ExerciseFile
                {
                    Id = 1, FileName = "1", Path = @"files\MainFiles\1.docx"
                },
                new ExerciseFile
                {
                    Id = 2, FileName = "2", Path = @"files\MainFiles\2.docx"
                },
                new ExerciseFile
                {
                    Id = 3, FileName = "3", Path = @"files\MainFiles\3.docx"
                },
                new ExerciseFile
                {
                    Id = 4, FileName = "4", Path = @"files\MainFiles\4.pptx"
                },
                new ExerciseFile
                {
                    Id = 5, FileName = "5", Path = @"files\MainFiles\5.docx"
                }
            );
        }
    }
}