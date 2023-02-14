using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Application.Repositories;

public interface IPhotoForMenuItemRepository
{
    Task AddPhotoForMenuItem(IFormFile file, Guid id,
        CancellationToken cancellationToken);

    Task<bool> DeletePhotoForMenuItem(string photoId, Guid id,
        CancellationToken cancellationToken);

    Task<bool> SetMainPhotoForMenuItem(string photoId, Guid id,
        CancellationToken cancellationToken);
}