using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

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
        if (result is false)
            return Result.Failure(DomainMessages.PhotoForMenuItem.CanNotSetAsMainPhoto(request.PhotoId));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.PhotoForMenuItem.PhotoSetAsMain(request.PhotoId));
    }
}