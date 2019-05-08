using System.Collections.Generic;

namespace UserDirectory.Domain.Entities
{
    public class UserIdentity
    {
        public UserIdentity()
        {
            UserIdentityRoles = new HashSet<UserIdentityRole>();
            UserIdentityGroups = new HashSet<UserIdentityGroup>();
        }

        public int Id { get; set; }

        public UserDetails UserDetails { get; set; }

        public ICollection<UserIdentityGroup> UserIdentityGroups { get; }

        public ICollection<UserIdentityRole> UserIdentityRoles { get; }
    }
}