using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> entity)
        {
            entity.Property(f => f.Path).IsRequired().HasMaxLength(300);
            
            entity.Property(f => f.FileName).IsRequired().HasMaxLength(100);
            
            entity.Property(f => f.FileType).HasMaxLength(20);

            entity.HasDiscriminator(f => f.FileType)
                .HasValue<File>("File")
                .HasValue<ExerciseFile>("ExerciseFile")
                .HasValue<StudentsExerciseFile>("StudentsExerciseFile");
        }
    }
}