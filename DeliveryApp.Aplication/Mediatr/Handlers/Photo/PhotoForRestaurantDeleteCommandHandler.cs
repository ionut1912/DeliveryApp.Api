using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class
    PhotoForRestaurantDeleteCommandHandler : ICommandHandler<PhotoForRestaurantDeleteCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoForRestaurantsRepository _photoForRestaurantsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForRestaurantDeleteCommandHandler(IPhotoForRestaurantsRepository photoForRestaurantsRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForRestaurantsRepository = photoForRestaurantsRepository ??
                                         throw new ArgumentNullException(nameof(photoForRestaurantsRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoForRestaurantDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var result =
            await _photoForRestaurantsRepository.DeletePhotoForRestaurant(request.PhotoId, request.Id,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.PhotoForRestaurant.CanNotDeletePhoto(request.PhotoId)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.PhotoForRestaurant.PhotoDeletedSuccessfully(request.PhotoId)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}