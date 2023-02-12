using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class PhotoSetMainCommandHandler : ICommandHandler<PhotoSetMainCommand, ResultT<Unit>>
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoSetMainCommandHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
    }

    public async Task<ResultT<Unit>> Handle(PhotoSetMainCommand request, CancellationToken cancellationToken)
    {
        return await _photoRepository.SetMainPhoto(request, cancellationToken);
    }
}