using Microsoft.EntityFrameworkCore;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Application.Interfaces
{
    public interface IUserDirectoryDbContext
    {
        DbSet<Group> Groups { get; }

        DbSet<Role> Roles { get; }

        DbSet<UserDetails> UserDetails { get; }

        DbSet<UserIdentity> UserIdentities { get; }

        DbSet<UserIdentityGroup> UserIdentityGroups { get; }

        DbSet<UserIdentityRole> UserIdentityRoles { get; }
    }
}