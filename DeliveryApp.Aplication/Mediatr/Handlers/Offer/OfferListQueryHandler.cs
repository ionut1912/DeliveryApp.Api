using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferListQueryHandler : IQueryHandler<ListQuery<Domain.Models.OfferDto>, ResultT<List<Domain.Models.OfferDto>>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferListQueryHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<ResultT<List<Domain.Models.OfferDto>>> Handle(ListQuery<Domain.Models.OfferDto> request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffers(request, cancellationToken);
    }
}