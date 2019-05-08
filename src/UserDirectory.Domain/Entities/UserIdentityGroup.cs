namespace UserDirectory.Domain.Entities
{
    public class UserIdentityGroup
    {
        public int UserIdentityId { get; set; }

        public int GroupId { get; set; }

        public UserIdentity UserIdentity { get; set; }

        public Group Group { get; set; }
    }
}