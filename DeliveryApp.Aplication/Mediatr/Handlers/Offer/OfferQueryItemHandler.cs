using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferQueryItemHandler : IQueryHandler<QueryItem<Offers>, Result<Offers>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferQueryItemHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<Offers>> Handle(QueryItem<Offers> request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffer(request, cancellationToken);
    }
}