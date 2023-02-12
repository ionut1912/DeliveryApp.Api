using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;


public class RestaurantController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RestaurantDto>),(int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all restaurants")]
    
    public async Task<ActionResult<IEnumerable<RestaurantDto>>>
        GetRestaurants()
    {
        return HandleResult(
            await Mediator.Send(new ListQuery<RestaurantDto>()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RestaurantDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult),(int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Get restaurant based on id")]
    public async Task<ActionResult<RestaurantDto>>
        GetRestaurant(Guid id)
    {
        return HandleResult(
            await Mediator.Send(new QueryItem<RestaurantDto>
                { Id = id }));
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(RestaurantDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult),(int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Update restaurants")]
    public async Task<ActionResult<RestaurantDto>> UpdateRestaurant(
        Guid id, RestaurantDto restaurantForUpdate)
    {
        return HandleResult(await Mediator.Send(new RestaurantEditCommand
            { Id = id, RestaurantForUpdate = restaurantForUpdate }));
    }

    [Authorize]
    [ProducesResponseType(typeof(RestaurantDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary ="Create restaurant")]
    [HttpPost]
    public async Task<ActionResult<RestaurantDto>> AddRestaurant(
        RestaurantDto restaurantForCreation)
    {
        return HandleResult(await Mediator.Send(new RestaurantCreateCommand
            { RestaurantForCreation = restaurantForCreation }));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Restaurants>>
        DeleteRestaurant(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteCommand { Id = id }));
    }
}