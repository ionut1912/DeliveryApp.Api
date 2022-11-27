using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class OfferListQueryHandler : IQueryHandler<ListQuery<Offers>, Result<List<Offers>>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferListQueryHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<List<Offers>>> Handle(ListQuery<Offers> request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffers(request, cancellationToken);
    }
}