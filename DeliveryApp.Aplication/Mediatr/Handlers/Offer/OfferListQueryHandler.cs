using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferListQueryHandler : IQueryHandler<ListQuery<Domain.Models.Offer>, Result<List<Domain.Models.Offer>>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferListQueryHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<List<Domain.Models.Offer>>> Handle(ListQuery<Domain.Models.Offer> request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffers(request, cancellationToken);
    }
}