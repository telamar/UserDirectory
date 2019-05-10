using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserDirectory.Application.Interfaces;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Application.UserIdentities.Commands.AddUserToRoleCommand
{
    public class AddUserToRoleCommandHandler : IRequestHandler<AddUserToRoleCommand>
    {
        private readonly IUserDirectoryDbContext userDirectoryDbContext;

        public AddUserToRoleCommandHandler(IUserDirectoryDbContext userDirectoryDbContext)
        {
            this.userDirectoryDbContext = userDirectoryDbContext;
        }

        public async Task<Unit> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
        {
            UserIdentity userIdentity = await GetUserIdentityAsync(request, cancellationToken);
            if (userIdentity != null && !HasUserRole(userIdentity, request))
            {
                if (await RoleExists(request, cancellationToken))
                {
                    await userDirectoryDbContext.UserIdentityRoles.AddAsync(CreateUserIdentityRole(request), cancellationToken);
                    await userDirectoryDbContext.SaveChangesAsync(cancellationToken);
                }
            }

            return Unit.Value;
        }

        private static bool HasUserRole(UserIdentity userIdentity, AddUserToRoleCommand request)
        {
            UserIdentityRole userIdentityRoleEntity = userIdentity
                .UserIdentityRoles
                .FirstOrDefault(userIdentityRole => userIdentityRole.RoleId == request.RoleId);

            return userIdentityRoleEntity != null;
        }

        private static UserIdentityRole CreateUserIdentityRole(AddUserToRoleCommand request)
            => new UserIdentityRole { UserIdentityId = request.UserIdentityId, RoleId = request.RoleId };

        private async Task<UserIdentity> GetUserIdentityAsync(AddUserToRoleCommand request, CancellationToken cancellationToken)
            => await userDirectoryDbContext
                .UserIdentities
                .Include(user => user.UserIdentityRoles)
                .FirstOrDefaultAsync(user => user.Id == request.UserIdentityId, cancellationToken);

        private async Task<bool> RoleExists(AddUserToRoleCommand request, CancellationToken cancellationToken)
            => await userDirectoryDbContext.Roles.AnyAsync(role => role.Id == request.RoleId, cancellationToken);
    }
}