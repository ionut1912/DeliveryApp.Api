using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Application.Repositories;

public interface IOfferRepository
{
    Task AddOffer(OfferDtoForCreation offerDto, CancellationToken cancellationToken);
    Task<bool> EditOffer(Guid id, OfferDtoForEdit offerDto, CancellationToken cancellationToken);

    Task<List<Offer>> GetOffers(CancellationToken cancellationToken);

    Task<Offer> GetOffer(Guid id, CancellationToken cancellationToken);
}