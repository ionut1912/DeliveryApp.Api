using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoDeleteCommandHandler : ICommandHandler<PhotoDeleteCommand, Result>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoDeleteCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(PhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _photoRepository.DeletePhoto(request.Id, cancellationToken);
        if (result is false) return Result.Failure($"Photo with id {request.Id} can not be deleted");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Photo deleted successfully");
    }
}