using System.Net;
using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

public class PhotoForRestaurantsController : BaseApiController
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
        var command = new PhotoForRestaurantCreateCommand
        {
            File = file,
            Id = id
        };
        return HandleResult(
            await Mediator.Send(command));
    }


    [HttpDelete("{photoId}/{restaurantId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Delete photo")]
    public async Task<ActionResult> Delete(string photoId, Guid restaurantId)
    {
        var command = new PhotoForRestaurantDeleteCommand
        {
            PhotoId = photoId,
            Id = restaurantId
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{photoId}/{restaurantId}/setMain")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify main photo")]
    public async Task<ActionResult> SetMain(string photoId, Guid restaurantId)
    {
        var command = new PhotoForRestaurantSetMainCommand
        {
            PhotoId = photoId,
            Id = restaurantId
        };
        return HandleResult(
            await Mediator.Send(command));
    }
}