using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class PhotoDeleteCommandHandler : ICommandHandler<PhotoDeleteCommand, Result<Unit>>
{
    private readonly IPhotoRepository _photoRepository;

    public PhotoDeleteCommandHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
    }

    public async Task<Result<Unit>> Handle(PhotoDeleteCommand request, CancellationToken cancellationToken)
    {
        return await _photoRepository.DeletePhoto(request, cancellationToken);
    }
}