using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class
    PhotoForMenuItemCreateCommandHandler : ICommandHandler<PhotoForMenuItemCreateCommand, Result>
{
    private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoForMenuItemCreateCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository,
        IUnitOfWork unitOfWork)
    {
        _photoForMenuItemRepository = photoForMenuItemRepository ??
                                      throw new ArgumentNullException(nameof(photoForMenuItemRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(PhotoForMenuItemCreateCommand request,
        CancellationToken cancellationToken)
    {
        await _photoForMenuItemRepository.AddPhotoForMenuItem(request.File, request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo added successfully");
    }
}