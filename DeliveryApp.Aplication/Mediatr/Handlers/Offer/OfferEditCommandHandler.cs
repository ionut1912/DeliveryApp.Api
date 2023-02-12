using DeliveryApp.Aplication.Mediatr.Commands.Offer;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Offer;

public class OfferEditCommandHandler : ICommandHandler<OfferEditCommand, Result>
{
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OfferEditCommandHandler(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<Result> Handle(OfferEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _offerRepository.EditOffer(request.Id, request.OfferDto, cancellationToken);
        if (result is false) return Result.Failure($"Offer with id {request.Id} can not be modified");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success($"Offer with id {request.Id} updated successfully");
    }
}