using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class PhotoControllerForMenuItems : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();


    [HttpPost("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Add photo")]
    public async Task<ActionResult> AddPhoto(IFormFile file, Guid id)
    {
        var command = new PhotoForMenuItemCreateCommand
        {
            File = file,
            Id = id
        };
        return HandleResult(
            await Mediator.Send(command));
    }


    [HttpDelete("{photoId}/{itemId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Delete photo")]
    public async Task<ActionResult> Delete(string photoId, Guid itemId)
    {
        var command = new PhotoForMenuItemDeleteCommand
        {
            PhotoId = photoId,
            ItemId = itemId
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{photoId}/{itemId}/setMain")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify main photo")]
    public async Task<ActionResult> SetMain(string photoId, Guid itemId)
    {
        var command = new PhotoForMenuItemSetMainCommand
        {
            PhotoId = photoId,
            ItemId = itemId
        };
        return HandleResult(
            await Mediator.Send(command));
    }
}