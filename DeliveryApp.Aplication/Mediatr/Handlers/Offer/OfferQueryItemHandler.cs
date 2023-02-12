using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferQueryItemHandler : IQueryHandler<QueryItem<Domain.Models.Offer>, ResultT<Domain.Models.Offer>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferQueryItemHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<ResultT<Domain.Models.Offer>> Handle(QueryItem<Domain.Models.Offer> request,
        CancellationToken cancellationToken)
    {
        var result = await _offerRepository.GetOffer(request.Id, cancellationToken);
        if (result == null) return ResultT<Domain.Models.Offer>.Failure($"Offer with id {request.Id} can not be found");
        return ResultT<Domain.Models.Offer>.Success(result);
    }
}