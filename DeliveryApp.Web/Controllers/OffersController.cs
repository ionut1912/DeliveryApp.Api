using System.Net;
using DeliveryApp.Application.Mediatr.Commands.Offer;
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
public class OffersController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult), (int)HttpStatusCode.BadRequest)]
    [SwaggerOperation(Summary = "Add offer")]
    public async Task<ActionResult> AddOffer(OfferDtoForCreation offerForCreation)
    {
        var command = new OfferCreateCommand
        {
            OfferDto = offerForCreation
        };
        return HandleResult(await Mediator.Send(command));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Offer>), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all offers")]
    public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
    {
        var query = new ListQuery<Offer>();
        return HandleResult(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Offer), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Get offer")]
    public async Task<ActionResult<OfferDtoForCreation>> GetOffer(Guid id)
    {
        var query = new QueryItem<Offer>
        {
            Id = id
        };
        return HandleResult(await Mediator.Send(query));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ActionResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Update offer")]
    public async Task<ActionResult> UpdateOffer(Guid id, OfferDtoForEdit offerForUpdate)
    {
        var command = new OfferEditCommand
        {
            Id = id,
            OfferDto = offerForUpdate
        };
        return HandleResult(await Mediator.Send(command));
    }
}