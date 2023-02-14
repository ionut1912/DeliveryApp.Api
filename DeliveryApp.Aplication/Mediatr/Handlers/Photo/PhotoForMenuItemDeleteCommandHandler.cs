using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoForMenuItemDeleteCommandHandler : ICommandHandler<PhotoForMenuItemDeleteCommand, Result>
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

    public async Task<Result> Handle(PhotoForMenuItemDeleteCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _photoForMenuItemRepository.DeletePhotoForMenuItem(request.PhotoId, request.ItemId,
                cancellationToken);
        if (result is false) return Result.Failure($"Photo with id {request.PhotoId} can not be deleted");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo deleted successfully");
    }
}