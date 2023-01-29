using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Aplication.Controllers;

[AllowAnonymous]
public class UserConfigController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserConfigs>>>
        GetUserConfigs()
    {
        return HandleResult(
            await Mediator.Send(new ListQuery<UserConfigs>()));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserConfigs>>
        GetUserConfig(Guid id)
    {
        return HandleResult(
            await Mediator.Send(new QueryItem<UserConfigs>
                { Id = id }));
    }

    [Authorize]
    [HttpGet("config/{username}")]
    public async Task<ActionResult<UserConfigs>> GetUserConfigByUsername(string username)
    {
        return HandleResult(await Mediator.Send(new UserConfigQueryItemByUsername { Username = username }));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<UserConfigs>> UpdateUserConfig(
        int id, UserConfigForUpdate configs)
    {
        return HandleResult(await Mediator.Send(new UserConfigsUpdateCommand
            { Id = id, Configs = configs }));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<UserConfigs>> AddUserConfigs(UserConfigForCreation userConfig)
    {
        return HandleResult(await Mediator.Send(new UserConfigCreateCommand
            { UserConfigs  = userConfig }));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserConfigs>>
        DeleteRestaurant(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteCommand { Id = id }));
    }
}