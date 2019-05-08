namespace UserDirectory.Domain.Entities
{
    public class UserIdentityRole
    {
        public int UserIdentityId { get; set; }

        public int RoleId { get; set; }

        public UserIdentity UserIdentity { get; set; }

        public Role Role { get; set; }
    }
}