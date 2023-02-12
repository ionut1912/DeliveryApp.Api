using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.UserConfigs;
using DeliveryApp.Aplication.Mediatr.Query;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class UserConfigController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserConfigDto>),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult),(int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get user configs")]
    public async Task<ActionResult<IEnumerable<UserConfigDto>>>
        GetUserConfigs()
    {
        return HandleResult(
            await Mediator.Send(new ListQuery<UserConfigDto>()));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserConfigDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get user config")]
    public async Task<ActionResult<UserConfigDto>>
        GetUserConfig(Guid id)
    {
        return HandleResult(
            await Mediator.Send(new QueryItem<UserConfigDto>
                { Id = id }));
    }

   //refactor to use expression builder on previous endpoint
    [HttpGet("config/{username}")]
    [ProducesResponseType(typeof(UserConfigDto),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]

    [SwaggerOperation(Summary = "Get user config")]
    public async Task<ActionResult<UserConfigDto>> GetUserConfigByUsername(string username)
    {
        return HandleResult(await Mediator.Send(new UserConfigQueryItemByUsername { Username = username }));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserConfigDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]

    [SwaggerOperation(Summary = "Update user config")]
    public async Task<ActionResult<UserConfigDto>> UpdateUserConfig(
        int id, UserConfigDto configs)
    {
        return HandleResult(await Mediator.Send(new UserConfigsUpdateCommand
            { Id = id, Configs = configs }));
    }


    [HttpPost]
    public async Task<ActionResult<UserConfigs>> AddUserConfigs(UserConfigDto userConfig)
    {
        return HandleResult(await Mediator.Send(new UserConfigCreateCommand
            { UserConfigs = userConfig }));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserConfigs>>
        DeleteRestaurant(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteCommand { Id = id }));
    }
}