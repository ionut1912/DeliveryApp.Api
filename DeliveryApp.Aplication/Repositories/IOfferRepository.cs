using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IOfferRepository
{
    Task<Result<Offer>> AddOffer(OfferCreateCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> EditOffer(OfferEditCommand command, CancellationToken cancellationToken);

    Task<Result<List<Offer>>> GetOffers(ListQuery<Offer> request,
        CancellationToken cancellationToken);

    Task<Result<Offer>> GetOffer(QueryItem<Offer> request, CancellationToken cancellationToken
    );
}