using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> entity)
        {
            
            entity.HasOne(tc => tc.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(tc => tc.TeacherId);
            
            entity.HasOne(tc => tc.Course)
                .WithMany(u => u.Teachers)
                .HasForeignKey(tc => tc.CourseId);
        }
    }
}