using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Repositories;

public interface IOfferRepository
{
    Task AddOffer(OfferDto offerDto, CancellationToken cancellationToken);
    Task<bool> EditOffer(Guid id,OfferDto offerDto, CancellationToken cancellationToken);

    Task<List<Offer>> GetOffers(CancellationToken cancellationToken);

    Task<Offer> GetOffer(Guid id, CancellationToken cancellationToken);
}