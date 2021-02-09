using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class ExerciseStudentConfiguration : IEntityTypeConfiguration<ExerciseStudent>
    {
        public void Configure(EntityTypeBuilder<ExerciseStudent> entity)
        {
            entity.HasOne(es => es.Student)
                .WithMany(s => s.Exercises)
                .HasForeignKey(es => es.StudentId);

            entity.HasOne(es => es.Exercise)
                .WithMany(e => e.Students)
                .HasForeignKey(es => es.ExerciseId);

            entity.HasMany(es => es.AttachedFiles)
                .WithOne(sef => sef.ExerciseStudent)
                .HasForeignKey(sef => sef.ExerciseStudentId);
        }
    }
}