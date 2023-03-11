using System.Net;
using DeliveryApp.Application.Mediatr.Commands.Order;
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
public class OrdersController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
    [SwaggerOperation(Summary = "Add order")]
    public async Task<ActionResult> AddOrder(OrderForCreationDto orderForCreation)
    {
        var command = new OrderCreateCommand
        {
            Order = orderForCreation
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all orders")]
    public async Task<ActionResult<IEnumerable<OrderForCreationDto>>> GetOrders()
    {
        var query = new ListQuery<Order>();
        return HandleResult(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Get order by id")]
    public async Task<ActionResult<Order>> GetOrder(Guid id)
    {
        var query = new QueryItem<Order>
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Edit order")]
    public async Task<ActionResult> UpdateOrder(Guid id, OrderForUpdateDto orderForUpdate)
    {
        var command = new OrderEditCommand
        {
            Id = id,
            OrderForUpdate = orderForUpdate
        };
        return HandleResult(await Mediator.Send(
            command));
    }
}