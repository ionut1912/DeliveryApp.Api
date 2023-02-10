using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Mediatr.Commands.Restaurant;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Aplication.Controllers;

[AllowAnonymous]
public class RestaurantController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Restaurants>>>
        GetRestaurants()
    {
        return HandleResult(
            await Mediator.Send(new ListQuery<Restaurants>()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurants>>
        GetRestaurant(Guid id)
    {
        return HandleResult(
            await Mediator.Send(new QueryItem<Restaurants>
                { Id = id }));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Restaurants>> UpdateRestaurant(
        Guid id, RestaurantForUpdate restaurantForUpdate)
    {
        return HandleResult(await Mediator.Send(new RestaurantEditCommand
            { Id = id, RestaurantForUpdate = restaurantForUpdate }));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Restaurants>> AddRestaurant(
        RestaurantForCreation restaurantForCreation)
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