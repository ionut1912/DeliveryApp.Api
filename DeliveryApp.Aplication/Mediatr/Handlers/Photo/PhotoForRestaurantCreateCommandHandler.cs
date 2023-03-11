using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoForRestaurantCreateCommandHandler : ICommandHandler<PhotoForRestaurantCreateCommand, Result>
{
    private readonly IPhotoForRestaurantsRepository _photoForRestaurantsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForRestaurantCreateCommandHandler(IPhotoForRestaurantsRepository photoForRestaurantsRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForRestaurantsRepository = photoForRestaurantsRepository ??
                                         throw new ArgumentNullException(nameof(photoForRestaurantsRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(PhotoForRestaurantCreateCommand request, CancellationToken cancellationToken)
    {
        await _photoForRestaurantsRepository.AddPhotoForRestaurant(request.File, request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo for restaurant added successfully");
    }
}