using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDirectory.Application.Groups.Commands.CreateGroup;

namespace UserDirectory.WebApi.Controllers
{
    public class GroupApiController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateGroupCommand createGroupCommand)
            => await ExecuteCommand(createGroupCommand);
    }
}