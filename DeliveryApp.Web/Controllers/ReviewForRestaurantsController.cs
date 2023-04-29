using System.Net;
using DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;
using DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.Contracts;
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
    public async Task<IActionResult> AddReviewForRestaurant(AddReviewForRestaurantRequest request)
    {
        var command = new ReviewForRestaurantCreateCommand
        {
            Request = request
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
    public async Task<IActionResult> EditReviewForRestaurant(Guid id, EditReviewForRestaurantRequest request)
    {
        var command = new ReviewForRestaurantEditCommand
        {
            Request = request,
            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get reviews for current user")]
    public async Task<ActionResult<List<CurrentUserReviewForRestaurant>>> GetReviewForCurrentUser()
    {
        var query = new ReviewForRestaurantGetCurrentUserQuery();
        return HandleResult(await Mediator.Send(query));
    }

    [HttpDelete("{id}/{language}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Delete review for restaurant")]
    public async Task<IActionResult> DeleteReviewForMenuItem(Guid id, string language)
    {
        var command = new ReviewForRestaurantDeleteCommand
        {
            Language = language,

            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }
}