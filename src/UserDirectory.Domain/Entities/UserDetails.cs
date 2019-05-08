namespace UserDirectory.Domain.Entities
{
    public class UserDetails
    {
        public int Id { get; set; }

        public int UserIdentityId { get; set; }

        public UserIdentity UserIdentity { get; set; }
    }
}