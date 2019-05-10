using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserDirectory.Application.Interfaces;

namespace UserDirectory.Application.UserIdentities.Queries.UserIdentityExists
{
    public class UserIdentityExistsQueryHandler : IRequestHandler<UserIdentityExistsQuery, bool>
    {
        private readonly IUserDirectoryDbContext userDirectoryDbContext;

        public UserIdentityExistsQueryHandler(IUserDirectoryDbContext userDirectoryDbContext)
        {
            this.userDirectoryDbContext = userDirectoryDbContext;
        }

        public async Task<bool> Handle(UserIdentityExistsQuery request, CancellationToken cancellationToken)
            => await userDirectoryDbContext.UserIdentities.AnyAsync(userIdentity => userIdentity.Id == request.UserIdentityId);
    }
}