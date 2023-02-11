using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.Offer>, Result<Domain.Models.Offer>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferQueryItemHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<Domain.Models.Offer>> Handle(QueryItem<Domain.Models.Offer> request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffer(request, cancellationToken);
    }
}