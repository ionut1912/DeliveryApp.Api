using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoModifyMainCommandHandler : ICommandHandler<PhotoModifyMainCommand, Result>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoModifyMainCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(PhotoModifyMainCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoRepository.ModifyMainPhoto(request.File, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.Photo.CanNotModifyMainPhoto());

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.Photo.MainPhotoModified());
    }
}