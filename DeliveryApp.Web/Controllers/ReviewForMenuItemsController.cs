using System.Net;
using DeliveryApp.Application.Mediatr.Commands.ReviewForMenuItem;
using DeliveryApp.Application.Mediatr.Query.ReviewForMenuItem;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Domain.DTO;
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
    public async Task<IActionResult> AddReviewForMenuItem(ReviewForMenuItemDto reviewForMenuItemDto)
    {
        var command = new ReviewForMenuItemCreateCommand
        {
            ReviewForMenuItemDto = reviewForMenuItemDto
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
    public async Task<IActionResult> EditReviewForMenuItem(Guid id, ReviewForMenuItemDto reviewForMenuItemDto)
    {
        var command = new ReviewForMenuItemEditCommand()
        {
            Id = id,
            ReviewForMenuItemDto = reviewForMenuItemDto
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpDelete("{id}/{menuItemId}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Delete review for menuitem")]
    public async Task<IActionResult> DeleteReviewForMenuItem(Guid id, Guid menuItemId)
    {
        var command = new ReviewForMenuItemDeleteCommand()
        {
            Id = id,
            MenuItemId = menuItemId
        };
        return HandleResult(await Mediator.Send(command));

    }
}