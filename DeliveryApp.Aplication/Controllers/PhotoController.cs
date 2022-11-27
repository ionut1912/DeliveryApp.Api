using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Aplication.Controllers;

[AllowAnonymous]
public class PhotoControoller : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [Authorize]
    [HttpPost("{email}")]
    public async Task<IActionResult> Add(IFormFile file, string email)
    {
        return HandleResult(await Mediator.Send(new PhotoAddCommand { File = file, email = email }));
    }

    [Authorize]
    [HttpDelete("{id}/{email}")]
    public async Task<IActionResult> Delete(string id, string email)
    {
        return HandleResult(await Mediator.Send(new PhotoDeleteCommand { Id = id, email = email }));
    }

    [Authorize]
    [HttpPost("{id}/{email}/setMain")]
    public async Task<IActionResult> SetMain(string id, string email)
    {
        return HandleResult(await Mediator.Send(new PhotoSetMainCommand { Id = id, email = email }));
    }
}