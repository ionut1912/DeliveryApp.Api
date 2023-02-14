using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoSetMainCommandHandler : ICommandHandler<PhotoSetMainCommand, Result>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoSetMainCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(PhotoSetMainCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoRepository.SetMainPhoto(request.Id, cancellationToken);
        if (result is false) return Result.Failure($"Photo with id {request.Id} can not be set as main photo");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo was set as main");
    }
}