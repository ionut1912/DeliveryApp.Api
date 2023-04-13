using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class
    PhotoForRestaurantCreateCommandHandler : ICommandHandler<PhotoForRestaurantCreateCommand, ResultT<JsonResponse>>
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

    public async Task<ResultT<JsonResponse>> Handle(PhotoForRestaurantCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _photoForRestaurantsRepository.AddPhotoForRestaurant(request.File, request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponse = new JsonResponse
        {
            Message = DomainMessages.PhotoForRestaurant.PhotoAddedSuccessfully
        };
        return ResultT<JsonResponse>.Success(jsonResponse);
    }
}