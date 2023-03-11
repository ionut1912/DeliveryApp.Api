using DeliveryApp.Application.Mediatr.Commands.Photo;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Photo;

public class PhotoCreateCommandHandler : ICommandHandler<PhotoCreateCommand, Result>
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhotoCreateCommandHandler(IPhotoRepository photoRepository, IUnitOfWork unitOfWork)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }


    public async Task<Result> Handle(PhotoCreateCommand request,
        CancellationToken cancellationToken)
    {
    
        await _photoRepository.AddPhoto(request.File, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.Photo.PhotoAddedSuccessfully);
    }
}