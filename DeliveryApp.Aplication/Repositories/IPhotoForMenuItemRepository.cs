using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Domain.Cloudinary.Photo;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IPhotoForMenuItemRepository
{
    Task<Result<PhotoForMenuItem>> AddPhotoForMenuItem(PhotoForMenuItemCreateCommand command,
        CancellationToken cancellationToken);

    Task<Result<Unit>> DeletePhotoForMenuItem(PhotoForMenuItemDeleteCommand command,
        CancellationToken cancellationToken);

    Task<Result<Unit>> SetMainPhotoForMenuItem(PhotoForMenuItemSetMainCommand command,
        CancellationToken cancellationToken);
}