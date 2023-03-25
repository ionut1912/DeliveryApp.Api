using System.Net;
using DeliveryApp.Application.Mediatr.Commands.Restaurant;
using DeliveryApp.Application.Mediatr.Query.Restaurant;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

public class RestaurantsController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RestaurantWithImage>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all restaurants")]
    public async Task<ActionResult<IEnumerable<RestaurantWithImage>>>
        GetRestaurants()
    {
        var query = new ListQuery<RestaurantWithImage>();
        return HandleResult(
            await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RestaurantWithImages), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Get restaurant based on id")]
    public async Task<ActionResult<RestaurantWithImages>>
        GetRestaurant(Guid id)
    {
        var query = new QueryItem<RestaurantWithImages>
        {
            Id = id
        };
        return HandleResult(
            await Mediator.Send(query));
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Update restaurants")]
    public async Task<ActionResult> UpdateRestaurant(
        Guid id, RestaurantDto restaurantForUpdate)
    {
        var command = new RestaurantEditCommand
        {
            Id = id,
            RestaurantForUpdate = restaurantForUpdate
        };
        return HandleResult(await Mediator.Send(command));
    }

    [Authorize]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UnauthorizedResult), (int)HttpStatusCode.Unauthorized)]
    [SwaggerOperation(Summary = "Create restaurant")]
    [HttpPost]
    public async Task<ActionResult> AddRestaurant(
        RestaurantDto restaurantForCreation)
    {
        var command = new RestaurantCreateCommand
        {
            RestaurantDto = restaurantForCreation
        };
        return HandleResult(await Mediator.Send(command));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Restaurants>>
        DeleteRestaurant(Guid id)
    {
        var command = new DeleteCommand
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet("getByCity/{city}")]
    [ProducesResponseType(typeof(RestaurantWithImage), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RestaurantWithImage>>
        GetRestaurants(string city)
    {
        var query = new RestaurantQueryItemByCity
        {
            City = city
        };
        return HandleResult(await Mediator.Send(query));
    }
}