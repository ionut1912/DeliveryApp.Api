using DeliveryApp.Application.Mediatr.Commands.Offer;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Offer;

public class OfferEditCommandHandler : ICommandHandler<OfferEditCommand, ResultT<JsonResponse>>
{
    private readonly IOfferRepository _offerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OfferEditCommandHandler(IOfferRepository offerRepository, IUnitOfWork unitOfWork)
    {
        _offerRepository = offerRepository ?? throw new ArgumentNullException(nameof(offerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<ResultT<JsonResponse>> Handle(OfferEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _offerRepository.EditOffer(request.Id, request.OfferDto, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Offer.CanNotEditOffer(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Offer.OfferEditedSuccessfully(request.Id)
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}