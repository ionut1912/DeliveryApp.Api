using System.Net;
using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DeliveryApp.Web.Controllers;

[Authorize]
public class ReviewForMenuItemsController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Add review for menuitem")]
    public async Task<IActionResult> AddReviewForMenuItem(AddReviewForMenuItemRequest request)
    {
        var command = new ReviewForMenuItemCreateCommand
        {
            Request = request
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet("{menuItemId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get reviews for menuitem")]
    public async Task<ActionResult<List<ReviewForMenuItem>>> GetReviewsForMenuItem(Guid menuItemId)
    {
        var query = new ReviewForMenuItemListQuery
        {
            MenuItemId = menuItemId
        };
        return HandleResult(await Mediator.Send(query));
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(UnauthorizedObjectResult), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get reviews for current user")]
    public async Task<ActionResult<List<CurrentUserReviewForMenuItem>>> GetReviewForCurrentUser()
    {
        var query = new ReviewForMenuItemCurrentUserQuery();
        return HandleResult(await Mediator.Send(query));
    }

    [HttpGet("{id}/{menuItemId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get review for menuitem")]
    public async Task<ActionResult<List<ReviewForMenuItem>>> GetReviewForMenuItem(Guid id, Guid menuItemId)
    {
        var query = new ReviewForMenuItemQueryItem
        {
            Id = id,
            MenuItemId = menuItemId
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Edit review for menuitem")]
    public async Task<IActionResult> EditReviewForMenuItem(Guid id,
        EditReviewForMenuItemRequest editReviewForMenuItemRequest)
    {
        var command = new ReviewForMenuItemEditCommand
        {
            Id = id,
            Request = editReviewForMenuItemRequest
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id}/{language}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Delete review for menuitem")]
    public async Task<IActionResult> DeleteReviewForMenuItem(Guid id, string language)
    {
        var command = new ReviewForMenuItemDeleteCommand
        {
            Language = language,
            Id = id
        };
        return HandleResult(await Mediator.Send(command));
    }
}