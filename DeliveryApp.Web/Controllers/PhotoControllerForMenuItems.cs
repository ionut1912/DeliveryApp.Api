
using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
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
    [ProducesResponseType(typeof(PhotoForMenuItem),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult),(int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Add photo")]
    public async Task<ActionResult<PhotoForMenuItem>> AddPhoto(IFormFile file, Guid id)
    {
        return HandleResult(
            await Mediator.Send(new PhotoForMenuItemCreateCommand { File = file, Id = id }));
    }


    [HttpDelete("{photoId}/{itemId}")]
    [ProducesResponseType(typeof(PhotoForMenuItem), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Delete photo")]
    public async Task<ActionResult<PhotoForMenuItem>> Delete(string photoId, Guid itemId)
    {
        return HandleResult(
            await Mediator.Send(new PhotoForMenuItemDeleteCommand { PhotoId = photoId, ItemId = itemId }));
    }

    [HttpPost("{photoId}/{itemId}/setMain")]
    [ProducesResponseType(typeof(PhotoForMenuItem), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify main photo")]
    public async Task<ActionResult<PhotoForMenuItem>> SetMain(string photoId, Guid itemId)
    {
        return HandleResult(
            await Mediator.Send(new PhotoForMenuItemDeleteCommand { PhotoId = photoId, ItemId = itemId }));
    }
}