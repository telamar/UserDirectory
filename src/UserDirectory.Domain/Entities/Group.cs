using System.Collections.Generic;

namespace UserDirectory.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            Roles = new HashSet<Role>();
            UserIdentityGroups = new HashSet<UserIdentityGroup>();
        }

        public int Id { get; set; }

        public ICollection<Role> Roles { get; }

        public ICollection<UserIdentityGroup> UserIdentityGroups { get; }
    }
}