using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Persistence.Configurations
{
    public class UserDetailsConfiguration : IEntityTypeConfiguration<UserDetails>
    {
        public void Configure(EntityTypeBuilder<UserDetails> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder
                .HasOne(entity => entity.UserIdentity)
                .WithOne(relatedEntity => relatedEntity.UserDetails)
                .HasForeignKey<UserDetails>(entity => entity.UserIdentityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}