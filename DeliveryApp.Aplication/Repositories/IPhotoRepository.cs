using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Aplication.Repositories;

public interface IPhotoRepository
{
    Task AddPhoto(IFormFile file, CancellationToken cancellationToken);
    Task<bool> DeletePhoto(string id, CancellationToken cancellationToken);
    Task<bool> SetMainPhoto(string id, CancellationToken cancellationToken);
}