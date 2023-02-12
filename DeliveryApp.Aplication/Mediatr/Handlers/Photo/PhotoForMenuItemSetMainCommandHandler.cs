using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class PhotoForMenuItemSetMainCommandHandler : ICommandHandler<PhotoForMenuItemSetMainCommand, Result>
{
    private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForMenuItemSetMainCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForMenuItemRepository = photoForMenuItemRepository ??
                                      throw new ArgumentNullException(nameof(photoForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(PhotoForMenuItemSetMainCommand request, CancellationToken cancellationToken)
    {
        var result =
            await _photoForMenuItemRepository.SetMainPhotoForMenuItem(request.PhotoId, request.ItemId,
                cancellationToken);
        if (result is false) return Result.Failure($"Photo with id {request.PhotoId} can not be set as main photo");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo was set as main");
    }
}