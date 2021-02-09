using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> entity)
        {
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasMany(e => e.AttachedFiles)
                .WithOne(ef => ef.Exercise)
                .HasForeignKey(ef => ef.ExerciseId);
        }
    }
}