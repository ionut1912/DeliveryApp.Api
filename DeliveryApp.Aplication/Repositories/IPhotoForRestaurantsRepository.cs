using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Application.Repositories;

public interface IPhotoForRestaurantsRepository
{
    Task AddPhotoForRestaurant(IFormFile file, Guid id,
        CancellationToken cancellationToken);

    Task<bool> DeletePhotoForRestaurant(string photoId, Guid id,
        CancellationToken cancellationToken);

    Task<bool> SetMainPhotoForRestaurant(string photoId, Guid id,
        CancellationToken cancellationToken);
}