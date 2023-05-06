using System.Net;
using DeliveryApp.Application.Mediatr.Commands.Order;
using DeliveryApp.Application.Mediatr.Query.Orders;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Contracts;
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
    public async Task<ActionResult> AddOrder(CreateOrderRequest request)
    {
        var command = new OrderCreateCommand
        {
            Request = request
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var query = new ListQuery<Order>();
        return HandleResult(await Mediator.Send(query));
    }

    [Authorize]
    [HttpGet("current")]
    [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get current user orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetCurrentUserOrders()
    {
        var query = new CurrentUserOrdersQuery();
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
    public async Task<ActionResult> UpdateOrder(Guid id, EditOrderRequest request)
    {
        var command = new OrderEditCommand
        {
            Id = id,
            Request = request
        };
        return HandleResult(await Mediator.Send(
            command));
    }
}