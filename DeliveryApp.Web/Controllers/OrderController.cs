using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[AllowAnonymous]
public class OrderController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    [ProducesResponseType(typeof(OrderForCreationDto),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult),(int)HttpStatusCode.BadRequest)]
    [SwaggerOperation(Summary = "Add order")]
    public async Task<ActionResult<OrderForCreationDto>> AddOrder(OrderForCreationDto orderForCreation)
    {
        return HandleResult(await Mediator.Send(new OrderCreateCommand { Order = orderForCreation }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderForCreationDto>),(int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all orders")]
    public async Task<ActionResult<IEnumerable<OrderForCreationDto>>> GetOrders()
    {
        return HandleResult(await Mediator.Send(new ListQuery<OrderForCreationDto>()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<OrderForCreationDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(IEnumerable<OrderForCreationDto>), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Get order by id")]
    public async Task<ActionResult<OrderForCreationDto>> GetOrder(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem<OrderForCreationDto> { Id = id }));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(OrderForCreationDto), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Edit order")]
    public async Task<ActionResult<OrderForCreationDto>> UpdateOrder(Guid id, OrderForUpdateDto orderForUpdate)
    {
        return HandleResult(await Mediator.Send(new OrderEditCommand
            { Id = id, OrderForUpdate = orderForUpdate }));
    }
}