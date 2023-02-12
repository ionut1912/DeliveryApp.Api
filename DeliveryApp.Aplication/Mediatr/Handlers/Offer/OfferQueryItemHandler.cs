using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.OfferDto>, ResultT<Domain.Models.OfferDto>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferQueryItemHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<ResultT<Domain.Models.OfferDto>> Handle(QueryItem<Domain.Models.OfferDto> request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.GetOffer(request, cancellationToken);
    }
}