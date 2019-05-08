using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder
                .HasOne(entity => entity.Group)
                .WithMany(relatedEntity => relatedEntity.Roles)
                .HasForeignKey(entity => entity.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}