using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class PhotoAddCommandHandler : ICommandHandler<PhotoAddCommand, Result<Photo>>
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoAddCommandHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
    }

    public async Task<Result<Photo>> Handle(PhotoAddCommand request,
        CancellationToken cancellationToken)
    {
        return await _photoRepository.AddPhoto(request, cancellationToken);
    }
}