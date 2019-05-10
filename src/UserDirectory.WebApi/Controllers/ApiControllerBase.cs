using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace UserDirectory.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ApiControllerBase : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => mediator ?? (mediator = HttpContext.RequestServices.GetService<IMediator>());

        protected async Task<IActionResult> ExecuteCommand<TCommand>(TCommand command)
            where TCommand : IRequest
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}