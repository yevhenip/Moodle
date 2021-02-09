using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moodle.Domain;

namespace Moodle.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasDiscriminator(u => u.UserType)
                .HasValue<User>("Admin")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher");
            
            entity.Property(u => u.UserType).HasMaxLength(15);
            entity.Property(u => u.FullName).HasMaxLength(55);
        }
    }
}