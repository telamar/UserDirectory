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

            builder
                .HasOne(entity => entity.Group)
                .WithMany(relatedEntity => relatedEntity.UserIdentityGroups)
                .HasForeignKey(entity => entity.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(entity => entity.UserIdentity)
                .WithMany(relatedEntity => relatedEntity.UserIdentityGroups)
                .HasForeignKey(entity => entity.UserIdentityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}