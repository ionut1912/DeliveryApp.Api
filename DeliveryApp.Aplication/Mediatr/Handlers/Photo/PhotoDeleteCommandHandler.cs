using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoDeleteCommandHandler : ICommandHandler<PhotoDeleteCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoDeleteCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoRepository.DeletePhoto(request.Id, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.Photo.CanNotDeletePhoto(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Photo.PhotoDeletedSuccessfully(request.Id)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}