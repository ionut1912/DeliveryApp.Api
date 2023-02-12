using System.Net;
using DeliveryApp.Aplication.Mediatr.Commands.Offer;
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
public class OfferController : BaseApiController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    [HttpPost]
    [ProducesResponseType(typeof(OfferDto),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult),(int)HttpStatusCode.BadRequest)]
    [SwaggerOperation(Summary = "Add offer")]
    public async Task<ActionResult<OfferDto>> AddOffer(OfferDto offerForCreation)
    {
        return HandleResult(await Mediator.Send(new OfferCreateCommand { OfferForCreation = offerForCreation }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OfferDto>),(int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Get all offers")]

    public async Task<ActionResult<IEnumerable<OfferDto>>> GetOffers()
    {
        return HandleResult(await Mediator.Send(new ListQuery<OfferDto>()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OfferDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(NotFoundObjectResult), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Get offer")]
    public async Task<ActionResult<OfferDto>> GetOffer(Guid id)
    {
        return HandleResult(await Mediator.Send(new QueryItem<OfferDto> { Id = id }));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(OfferDto),(int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Update offer")]
    public async Task<ActionResult<OfferDto>> UpdateOffer(Guid id, OfferDto offerForUpdate)
    {
        return HandleResult(await Mediator.Send(new OfferEditCommand
            { Id = id, OfferForUpdate = offerForUpdate }));
    }
}