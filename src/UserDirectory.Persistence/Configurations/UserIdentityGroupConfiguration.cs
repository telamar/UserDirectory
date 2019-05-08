using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Persistence.Configurations
{
    public class UserIdentityGroupConfiguration : IEntityTypeConfiguration<UserIdentityGroup>
    {
        public void Configure(EntityTypeBuilder<UserIdentityGroup> builder)
        {
            builder.HasKey(entity => new { entity.UserIdentityId, entity.GroupId });
        }
    }
}