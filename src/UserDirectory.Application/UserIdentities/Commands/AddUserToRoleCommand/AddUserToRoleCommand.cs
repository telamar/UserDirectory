using MediatR;

namespace UserDirectory.Application.UserIdentities.Commands.AddUserToRoleCommand
{
    public class AddUserToRoleCommand : IRequest
    {
        public AddUserToRoleCommand(int roleId, int userIdentityId)
        {
            RoleId = roleId;
            UserIdentityId = userIdentityId;
        }

        public int RoleId { get; }

        public int UserIdentityId { get; }
    }
}