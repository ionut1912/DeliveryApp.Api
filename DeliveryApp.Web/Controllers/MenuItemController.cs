using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
    public async Task<ActionResult<MenuItemDto>> AddMenuItem(MenuItemDto menuItemForCreation)
    {
        return HandleResult(
            await Mediator.Send(new MenuItemCreateCommand { MenuItemForCreation = menuItemForCreation }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<MenuItemDto>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all menu items")]
    public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
    {
        return HandleResult(await Mediator.Send(new ListQuery<MenuItemDto>()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MenuItemDto),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult),(int)HttpStatusCode.NotFound)]
    [SwaggerOperation("Get menu item based on id")]
    public async Task<ActionResult<MenuItemDto>> GetMenuItems(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem<MenuItemDto> { Id = id }));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(MenuItemDto),(int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Update menu item")]
    public async Task<ActionResult<MenuItemDto>> UpdateMneuItems(Guid id, MenuItemDto menuItemForUpdate)
    {
        return HandleResult(await Mediator.Send(new MenuItemEditCommand
            { Id = id, MenuItemForUpdate = menuItemForUpdate }));
    }
}