using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Aplication.Controllers;

[AllowAnonymous]
public class MenuItemController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    public async Task<ActionResult<MenuItems>> AddMenuItem(MenuItemForCreation menuItemForCreation)
    {
        return HandleResult(
            await Mediator.Send(new MenuItemCreateCommand { menuItemForCreation = menuItemForCreation }));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItems()
    {
        return HandleResult(await Mediator.Send(new ListQuery<MenuItems>()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuItems>> GetMenuItems(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem<MenuItems> { id = id }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MenuItems>> UpdateMneuItems(Guid id, MenuItemForUpdate menuItemForUpdate)
    {
        return HandleResult(await Mediator.Send(new MenuItemEditCommand
            { id = id, menuItemForUpdate = menuItemForUpdate }));
    }
}