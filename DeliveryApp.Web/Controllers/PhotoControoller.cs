using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
        return HandleResult(await Mediator.Send(new PhotoAddCommand { File = file }));
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(PhotoForMenuItem), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Delete photo")]
    public async Task<IActionResult> Delete(string id)
    {
        return HandleResult(await Mediator.Send(new PhotoDeleteCommand { Id = id }));
    }


    [HttpPost("{id}/setMain")]
    [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify main photo")]
    public async Task<IActionResult> SetMain(string id)
    {
        return HandleResult(await Mediator.Send(new PhotoSetMainCommand { Id = id }));
    }
}