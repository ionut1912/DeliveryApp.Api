using System.Net;
using DeliveryApp.Application.Mediatr.Commands.MenuItem;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[AllowAnonymous]
public class MenuItemController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
    [SwaggerOperation(Summary = "Add a menu item")]
    public async Task<ActionResult> AddMenuItem(MenuItemDto menuItemForCreation)
    {
        var command = new MenuItemCreateCommand
        {
            MenuItemDto = menuItemForCreation
        };
        return HandleResult(
            await Mediator.Send(command));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MenuItem>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all menu items")]
    public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
    {
        var query = new ListQuery<MenuItem>();
        return HandleResult(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MenuItem), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation("Get menu item based on id")]
    public async Task<ActionResult<MenuItem>> GetMenuItems(Guid id)
    {
        var query = new QueryItem<MenuItem>
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Update menu item")]
    public async Task<ActionResult> UpdateMneuItems(Guid id, MenuItemDto menuItemForUpdate)
    {
        var command = new MenuItemEditCommand
        {
            Id = id,
            MenuItemDto = menuItemForUpdate
        };
        return HandleResult(await Mediator.Send(command));
    }
}