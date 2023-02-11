using DeliveryApp.Aplication.Mediatr.Commands.MenuItem;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Web.Controllers;

[AllowAnonymous]
public class MenuItemController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    public async Task<ActionResult<MenuItem>> AddMenuItem(MenuItem menuItemForCreation)
    {
        return HandleResult(
            await Mediator.Send(new MenuItemCreateCommand { MenuItemForCreation = menuItemForCreation }));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
    {
        return HandleResult(await Mediator.Send(new ListQuery<MenuItem>()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MenuItem>> GetMenuItems(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem<MenuItem> { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MenuItem>> UpdateMneuItems(Guid id, MenuItem menuItemForUpdate)
    {
        return HandleResult(await Mediator.Send(new MenuItemEditCommand
            { Id = id, MenuItemForUpdate = menuItemForUpdate }));
    }
}