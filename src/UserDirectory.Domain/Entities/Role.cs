using System.Collections.Generic;

namespace UserDirectory.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            UserIdentityRoles = new HashSet<UserIdentityRole>();
        }

        public int Id { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<UserIdentityRole> UserIdentityRoles { get; }
    }
}