using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoForRestaurantSetMainCommandHandler : ICommandHandler<PhotoForRestaurantSetMainCommand, Result>
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

    public async Task<Result> Handle(PhotoForRestaurantSetMainCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _photoForRestaurantsRepository.SetMainPhotoForRestaurant(request.PhotoId, request.Id,
                cancellationToken);
        if (result is false) return Result.Failure($"Photo with id {request.PhotoId} can not be set as main photo");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo was set as main");
    }
}