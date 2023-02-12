using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Photo;

public class PhotoForMenuItemSetMainCommandHandler : ICommandHandler<PhotoForMenuItemSetMainCommand, ResultT<Unit>>
{
    private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;

    public PhotoForMenuItemSetMainCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository)
    {
        _photoForMenuItemRepository = photoForMenuItemRepository ??
                                      throw new ArgumentNullException(nameof(photoForMenuItemRepository));
    }

    public async Task<ResultT<Unit>> Handle(PhotoForMenuItemSetMainCommand request, CancellationToken cancellationToken)
    {
        return await _photoForMenuItemRepository.SetMainPhotoForMenuItem(request, cancellationToken);
    }
}