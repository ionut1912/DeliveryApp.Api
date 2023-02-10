using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class PhotoSetMainCommandHandler : ICommandHandler<PhotoSetMainCommand, Result<Unit>>
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoSetMainCommandHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
    }

    public async Task<Result<Unit>> Handle(PhotoSetMainCommand request, CancellationToken cancellationToken)
    {
        return await _photoRepository.SetMainPhoto(request, cancellationToken);
    }
}