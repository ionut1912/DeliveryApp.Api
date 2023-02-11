using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class PhotoControoller : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();


    [HttpPost]
    public async Task<IActionResult> Add(IFormFile file)
    {
        return HandleResult(await Mediator.Send(new PhotoAddCommand { File = file }));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return HandleResult(await Mediator.Send(new PhotoDeleteCommand { Id = id }));
    }


    [HttpPost("{id}/setMain")]
    public async Task<IActionResult> SetMain(string id)
    {
        return HandleResult(await Mediator.Send(new PhotoSetMainCommand { Id = id }));
    }
}