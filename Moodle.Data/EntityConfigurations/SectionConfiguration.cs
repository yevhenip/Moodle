using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> entity)
        {
            entity.Property(s => s.Header).IsRequired().HasMaxLength(100);

            entity.Property(s => s.Description).HasMaxLength(1000);

            entity.HasMany(s => s.Exercises)
                .WithOne(e => e.Section)
                .HasForeignKey(e => e.SectionId);
        }
    }
}