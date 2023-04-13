using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoModifyMainCommandHandler : ICommandHandler<PhotoModifyMainCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoModifyMainCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoModifyMainCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoRepository.ModifyMainPhoto(request.File, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Photo.CanNotModifyMainPhoto()
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Photo.MainPhotoModified()
        };

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}