using System.Net;
using DeliveryApp.Application.Mediatr.Commands.UserConfigs;
using DeliveryApp.Application.Mediatr.Query.UserConfig;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class UserConfigsController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserConfig>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get user configs")]
    public async Task<ActionResult<IEnumerable<UserConfig>>>
        GetUserConfigs()
    {
        var query = new ListQuery<UserConfig>();
        return HandleResult(
            await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserConfig), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get user config")]
    public async Task<ActionResult<UserConfigDto>>
        GetUserConfig(Guid id)
    {
        var query = new QueryItem<UserConfig>
        {
            Id = id
        };
        return HandleResult(
            await Mediator.Send(query));
    }


    [HttpGet("config/{username}")]
    [ProducesResponseType(typeof(UserConfig), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get user config")]
    public async Task<ActionResult<UserConfig>> GetUserConfigByUsername(string username)
    {
        var query = new UserConfigQueryItemByUsername
        {
            Username = username
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Update user config")]
    public async Task<ActionResult> UpdateUserConfig(
        Guid id, EditUserConfigRequest request)
    {
        var command = new UserConfigsUpdateCommand
        {
            Id = id,
            Request = request
          
        };
        return HandleResult(await Mediator.Send(command));
    }


    [HttpPost]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Create user config")]
    public async Task<ActionResult> AddUserConfigs(AddUserConfigRequest request)
    {
        var command = new UserConfigCreateCommand
        {
           Request = request
        };
        return HandleResult(await Mediator.Send(command));
    }
}