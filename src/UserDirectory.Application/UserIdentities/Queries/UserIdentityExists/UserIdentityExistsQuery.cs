using MediatR;

namespace UserDirectory.Application.UserIdentities.Queries.UserIdentityExists
{
    public class UserIdentityExistsQuery : IRequest<bool>
    {
        public UserIdentityExistsQuery(int userIdentityId)
        {
            UserIdentityId = userIdentityId;
        }

        public int UserIdentityId { get; }
    }
}