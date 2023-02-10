using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferCreateCommandHandler : ICommandHandler<OfferCreateCommand, Result<Offers>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferCreateCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<Offers>> Handle(OfferCreateCommand request, CancellationToken cancellationToken)
    {
        return await _offerRepository.AddOffer(request, cancellationToken);
    }
}