using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class
    PhotoForRestaurantSetMainCommandHandler : ICommandHandler<PhotoForRestaurantSetMainCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoForRestaurantsRepository _photoForRestaurantsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForRestaurantSetMainCommandHandler(IPhotoForRestaurantsRepository photoForRestaurantsRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForRestaurantsRepository = photoForRestaurantsRepository ??
                                         throw new ArgumentNullException(nameof(photoForRestaurantsRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoForRestaurantSetMainCommand request,
        CancellationToken cancellationToken)
    {
        var result =
            await _photoForRestaurantsRepository.SetMainPhotoForRestaurant(request.PhotoId, request.Id,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.PhotoForRestaurant.CanNotSetAsMainPhoto(request.PhotoId)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.PhotoForRestaurant.PhotoSetAsMain(request.PhotoId)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}