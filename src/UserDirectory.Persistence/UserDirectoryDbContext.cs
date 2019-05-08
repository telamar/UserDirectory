using Microsoft.EntityFrameworkCore;
using UserDirectory.Application.Interfaces;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Persistence
{
    public class UserDirectoryDbContext : DbContext, IUserDirectoryDbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<UserIdentity> UserIdentities { get; set; }

        public DbSet<UserIdentityGroup> UserIdentityGroups { get; set; }

        public DbSet<UserIdentityRole> UserIdentityRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDirectoryDbContext).Assembly);
        }
    }
}