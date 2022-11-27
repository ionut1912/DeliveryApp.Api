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
public class OrderController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    public async Task<ActionResult<Orders>> AddOrder(OrderForCreation orderForCreation)
    {
        return HandleResult(await Mediator.Send(new OrderCreateCommand { order = orderForCreation }));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
    {
        return HandleResult(await Mediator.Send(new ListQuery<Orders>()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Orders>> GetOrder(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem<Orders> { id = id }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Orders>> UpdateOrder(Guid id, OrderForUpdate orderForUpdate)
    {
        return HandleResult(await Mediator.Send(new OrderEditCommand
            { id = id, orderForUpdate = orderForUpdate }));
    }
}