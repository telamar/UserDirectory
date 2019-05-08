using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Persistence.Configurations
{
    public class UserIdentityConfiguration : IEntityTypeConfiguration<UserIdentity>
    {
        public void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            builder.HasKey(entity => entity.Id);
        }
    }
}