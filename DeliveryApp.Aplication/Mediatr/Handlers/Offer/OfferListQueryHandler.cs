using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferListQueryHandler : IQueryHandler<ListQuery<Domain.Models.Offer>, ResultT<List<Domain.Models.Offer>>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferListQueryHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<ResultT<List<Domain.Models.Offer>>> Handle(ListQuery<Domain.Models.Offer> request,
        CancellationToken cancellationToken)
    {
        var result = await _offerRepository.GetOffers(cancellationToken);
        return ResultT<List<Domain.Models.Offer>>.Success(result);
    }
}