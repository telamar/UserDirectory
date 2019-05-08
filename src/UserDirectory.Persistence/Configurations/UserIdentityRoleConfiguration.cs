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
        }
    }
}