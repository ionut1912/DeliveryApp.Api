using System.Net;
using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using DeliveryApp.Application.Mediatr.CommandValidators.ReviewForRestaurant;
using DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class ReviewForRestaurantsController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Add review for restaurant")]
    public async Task<IActionResult> AddReviewForRestaurant(ReviewForRestaurantDto reviewForRestaurantDto)
    {
        var command = new ReviewForRestaurantCreateCommand
        {
            ReviewForRestaurantDto = reviewForRestaurantDto
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet("{restaurantId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get reviews for restaurant")]
    public async Task<ActionResult<List<ReviewForRestaurant>>> GetReviewsForRestaurant(Guid restaurantId)
    {
        var query = new ReviewForRestaurantListQuery
        {
            RestaurantId = restaurantId
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpGet("{id}/{restaurantId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get review for restaurant")]
    public async Task<ActionResult<List<ReviewForRestaurant>>> GetReviewForRestaurant(Guid id, Guid restaurantId)
    {
        var query = new ReviewForRestaurantQueryItem
        {
            Id = id,
            RestaurantId = restaurantId
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Edit review for restaurant")]
    public async Task<IActionResult> EditReviewForRestaurant(Guid id, ReviewForRestaurantDto reviewForRestaurantDto)
    {
        var command = new ReviewForRestaurantEditCommand
        {
            Id = id,
            ReviewForRestaurant = reviewForRestaurantDto
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Delete review for restaurant")]
    public async Task<IActionResult> DeleteReviewForMenuItem(Guid id)
    {
        var command = new ReviewForRestaurantDeleteCommand
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }
}