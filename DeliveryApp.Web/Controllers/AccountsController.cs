﻿using System.Net;
using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Mediatr.Query.Account;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountsController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost("login")]
    [ProducesResponseType(typeof(ActionResult<UserDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var command = new LoginCommand
        {
            LoginDto = loginDto
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
    [SwaggerOperation(Summary = "Create account")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var command = new CreateAccountCommand
        {
            RegisterDto = registerDto,
            ModelState = ModelState
        };
        return HandleResult(await Mediator.Send(command));
    }


    [Authorize]
    [ProducesResponseType(typeof(ActionResult<UserDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get current user information")]
    [HttpGet("current")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var query = new GetCurrentUserQuery
        {
            Username = User.Identity.Name
        };
        return HandleResult(await Mediator.Send(query));
    }

    [Authorize]
    [ProducesResponseType(typeof(ActionResult<UserDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [HttpPut("current")]
    public async Task<ActionResult<UserDto>> EditCurrentUser(UserDto userToBeEdited)
    {
        var command = new EditUserCommand
        {
            UserToBeEdited = userToBeEdited,
            ModelState = ModelState
        };
        return HandleResult(await Mediator.Send(command));
    }
}