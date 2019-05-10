using MediatR;

namespace UserDirectory.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest
    {
        public CreateGroupCommand(string name, int userIdentityId)
        {
            Name = name;
            UserIdentityId = userIdentityId;
        }

        public string Name { get; }

        public int UserIdentityId { get; }
    }
}