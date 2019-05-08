using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Persistence.Configurations
{
    public class UserIdentityRoleConfiguration : IEntityTypeConfiguration<UserIdentityRole>
    {
        public void Configure(EntityTypeBuilder<UserIdentityRole> builder)
        {
            builder.HasKey(entity => new { entity.UserIdentityId, entity.RoleId });

            builder
                .HasOne(entity => entity.Role)
                .WithMany(relatedEntity => relatedEntity.UserIdentityRoles)
                .HasForeignKey(entity => entity.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(entity => entity.UserIdentity)
                .WithMany(relatedEntity => relatedEntity.UserIdentityRoles)
                .HasForeignKey(entity => entity.UserIdentityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}