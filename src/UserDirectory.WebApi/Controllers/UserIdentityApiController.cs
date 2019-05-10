using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserDirectory.Application.UserIdentities.Commands.AddUserToRoleCommand;

namespace UserDirectory.WebApi.Controllers
{
    public class UserIdentityApiController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddUserToRole([FromBody]AddUserToRoleCommand addUserToRoleCommand)
            => await ExecuteCommand(addUserToRoleCommand);
    }
}