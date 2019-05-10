using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserDirectory.Application.Interfaces;
using UserDirectory.Application.UserIdentities.Queries.UserIdentityExists;
using UserDirectory.Domain.Entities;

namespace UserDirectory.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommndHandler : IRequestHandler<CreateGroupCommand>
    {
        private readonly IUserDirectoryDbContext userDirectoryDbContext;
        private readonly IRequestHandler<UserIdentityExistsQuery, bool> userIdentityExistsQueryHandler;

        public CreateGroupCommndHandler(
            IUserDirectoryDbContext userDirectoryDbContext,
            IRequestHandler<UserIdentityExistsQuery, bool> userIdentityExistsQueryHandler)
        {
            this.userDirectoryDbContext = userDirectoryDbContext;
            this.userIdentityExistsQueryHandler = userIdentityExistsQueryHandler;
        }

        public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            if (await UserIdentityExists(request.UserIdentityId, cancellationToken))
            {
                Group group = CreateGroup(request);
                await userDirectoryDbContext.Groups.AddAsync(group, cancellationToken);

                await userDirectoryDbContext.UserIdentityGroups.AddAsync(
                    CreateUserIdentityGroup(request, group),
                    cancellationToken);

                await userDirectoryDbContext.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }

        private static Group CreateGroup(CreateGroupCommand request) => new Group { Name = request.Name };

        private static UserIdentityGroup CreateUserIdentityGroup(CreateGroupCommand request, Group group)
            => new UserIdentityGroup { Group = group, UserIdentityId = request.UserIdentityId };

        private async Task<bool> UserIdentityExists(int userIdentityId, CancellationToken cancellationToken)
            => await userIdentityExistsQueryHandler.Handle(new UserIdentityExistsQuery(userIdentityId), cancellationToken);
    }
}