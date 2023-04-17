using System.Net;
using CloudinaryDotNet.Actions;
using DeliveryApp.Application.Mediatr.Commands.Account;
using DeliveryApp.Application.Mediatr.Query.Account;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
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
    [ProducesResponseType(typeof(ActionResult<User>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get current user information")]
    [HttpGet("current")]
    public async Task<ActionResult<User>> GetCurrentUser()
    {
        var query = new GetCurrentUserQuery
        {
            Username = User.Identity.Name
        };
        return HandleResult(await Mediator.Send(query));
    }

    [Authorize]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify current user details")]
    [HttpPut("current")]
    public async Task<ActionResult> EditCurrentUser(UserDto userToBeEdited)
    {
        var command = new EditUserCommand
        {
            UserToBeEdited = userToBeEdited,
            ModelState = ModelState
        };
        return HandleResult(await Mediator.Send(command));
    }

    [Authorize]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Modify current user address")]
    [HttpPut("current/address")]
    public async Task<ActionResult> EditUserAddress(UserAddressesForCreation userAddressesForCreation)
    {
        var command = new EditUserAddressCommand
        {
            UserAddressesForCreation = userAddressesForCreation
        };
        return HandleResult(await Mediator.Send(command));
    }

    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ActionResult<User>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Get all users")]

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var query = new GetAllUsersQuery();
        return HandleResult(await Mediator.Send(query));
    }

}