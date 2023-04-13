using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class
    PhotoForMenuItemDeleteCommandHandler : ICommandHandler<PhotoForMenuItemDeleteCommand, ResultT<JsonResponse>>
{
    private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForMenuItemDeleteCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForMenuItemRepository = photoForMenuItemRepository ??
                                      throw new ArgumentNullException(nameof(photoForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(PhotoForMenuItemDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var result =
            await _photoForMenuItemRepository.DeletePhotoForMenuItem(request.PhotoId, request.ItemId,
                cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = DomainMessages.PhotoForMenuItem.CanNotDeletePhoto(request.PhotoId)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.PhotoForMenuItem.PhotoDeletedSuccessfully(request.PhotoId)
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}