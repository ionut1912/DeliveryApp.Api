using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferEditCommandHandler : ICommandHandler<OfferEditCommand, Result<Unit>>
{
    private readonly IOfferRepository _offerRepository;

    public OfferEditCommandHandler(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
    }

    public async Task<Result<Unit>> Handle(OfferEditCommand request, CancellationToken cancellationToken)
    {
        return await _offerRepository.EditOffer(request, cancellationToken);
    }
}