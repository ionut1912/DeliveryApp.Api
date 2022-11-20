using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{

    public class PhotoForMenuItemDeleteCommandHandler : ICommandHandler<PhotoForMenuItemDeleteCommand, Result<Unit>>
    {
        private readonly IPhotoForMenuItemRepository _photoForMenuItemRepository;

        public PhotoForMenuItemDeleteCommandHandler(IPhotoForMenuItemRepository photoForMenuItemRepository)
        {
            _photoForMenuItemRepository = photoForMenuItemRepository ??
                                          throw new ArgumentNullException(nameof(photoForMenuItemRepository));
        }

        public async Task<Result<Unit>> Handle(PhotoForMenuItemDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _photoForMenuItemRepository.DeletePhotoForMenuItem(request, cancellationToken);
        }
    }
}
