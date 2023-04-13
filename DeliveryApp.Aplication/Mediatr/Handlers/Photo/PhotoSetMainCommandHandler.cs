using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoSetMainCommandHandler : ICommandHandler<PhotoSetMainCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoSetMainCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoSetMainCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoRepository.SetMainPhoto(request.Id, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Photo.CanNotSetMainPhoto(request.Id)
            };

            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Photo.PhotoSetAsMain(request.Id)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}