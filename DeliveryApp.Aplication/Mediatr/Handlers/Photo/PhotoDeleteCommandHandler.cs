using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

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
        if (result is false) return Result.Failure(DomainMessages.Photo.CanNotDeletePhoto(request.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.Photo.PhotoDeletedSuccessfully(request.Id));
    }
}