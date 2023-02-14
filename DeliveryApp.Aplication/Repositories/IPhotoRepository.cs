using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Application.Repositories;

public interface IPhotoRepository
{
    Task AddPhoto(IFormFile file, CancellationToken cancellationToken);
    Task<bool> DeletePhoto(string id, CancellationToken cancellationToken);
    Task<bool> SetMainPhoto(string id, CancellationToken cancellationToken);
}