using DeliveryApp.Application.Mediatr.Commands.Offer;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Offer;

public class OfferCreateCommandHandler : ICommandHandler<OfferCreateCommand, ResultT<JsonResponse>>
{
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OfferCreateCommandHandler(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
    {
        _offerRepository = offerRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<ResultT<JsonResponse>> Handle(OfferCreateCommand request,
        CancellationToken cancellationToken)

    {
        await _offerRepository.AddOffer(request.OfferDto, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessagesEn.Offer.OfferAddedSuccessfully
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}