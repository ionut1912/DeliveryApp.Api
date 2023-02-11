using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferCreateCommandHandler : ICommandHandler<OfferCreateCommand, Result<Domain.Models.Offer>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferCreateCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<Domain.Models.Offer>> Handle(OfferCreateCommand request,
        CancellationToken cancellationToken)
    {
        return await _offerRepository.AddOffer(request, cancellationToken);
    }
}