using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferCreateCommandHandler : ICommandHandler<OfferCreateCommand, Result>
{
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OfferCreateCommandHandler(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
    {
        _offerRepository = offerRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result> Handle(OfferCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _offerRepository.AddOffer(request.OfferDto, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Offer created successfully");
    }
}