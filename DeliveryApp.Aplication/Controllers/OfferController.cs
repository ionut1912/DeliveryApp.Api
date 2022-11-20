using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Controllers;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using DeliveryApp.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Aplication.Controllers
{
    [AllowAnonymous]
    public class OfferController : BaseApiController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        [HttpPost]
        public async Task<ActionResult<Offers>> AddOffer(OfferForCreation offerForCreation)
        {
            return HandleResult(await Mediator.Send(new OfferCreateCommand { offerForCreation = offerForCreation }));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offers>>> GetOffers()
        {
            return HandleResult(await Mediator.Send(new ListQuery<Offers>()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offers>> GetOffer(Guid id)
        {
            return HandleResult(await Mediator.Send(new QueryItem<Offers> { id = id }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Offers>> UpdateOffer(Guid id, OfferForUpdate offerForUpdate)
        {
            return HandleResult(await Mediator.Send(new OfferEditCommand
                { id = id, offerForUpdate = offerForUpdate }));
        }
    }
}
