using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> entity)
        {
            entity.Property(g => g.Name).IsRequired().HasMaxLength(10);

           
            
            entity.HasOne(g => g.SuperVisor)
                .WithOne(t => t.Group)
                .HasForeignKey<Group>(g => g.SuperVisorId).OnDelete(DeleteBehavior.SetNull);
            
            entity.HasOne(g => g.HeadMan)
                .WithOne(s => s.HeadGroup)
                .HasForeignKey<Group>(g => g.HeadManId).OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(u => u.GroupId).OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(g => g.Courses)
                .WithOne(c => c.Group)
                .HasForeignKey(c => c.GroupId);
        }
    }
}