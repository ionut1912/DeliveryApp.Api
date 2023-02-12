using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class PhotoControoller : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();


    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Add photo")]
    public async Task<IActionResult> Add(IFormFile file)
    {
        var command = new PhotoAddCommand
        {
            File = file
        };
        return HandleResult(await Mediator.Send(command));
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Delete photo")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new PhotoDeleteCommand
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }


    [HttpPost("{id}/setMain")]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify main photo")]
    public async Task<IActionResult> SetMain(string id)
    {
        var command = new PhotoSetMainCommand
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }
}