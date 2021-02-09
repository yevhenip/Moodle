using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moodle.Core.Interfaces.Data.UnitOfWork;
using Moodle.Data.Extensions;
using Moodle.Domain;

namespace Moodle.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IUnitOfWork
    {
        public override DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ExerciseFile> ExerciseFiles { get; set; }
        public DbSet<StudentsExerciseFile> StudentsExerciseFiles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}