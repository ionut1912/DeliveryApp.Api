using DeliveryApp.Application.Repositories;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class PhotoForRestaurantService : IPhotoForRestaurantsRepository
{
    private readonly DeliveryContext _context;
    private readonly IPhotoAccessor _photoAccessor;

    public PhotoForRestaurantService(DeliveryContext context, IPhotoAccessor photoAccessor)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _photoAccessor = photoAccessor ?? throw new ArgumentNullException(nameof(photoAccessor));
    }

    public async Task AddPhotoForRestaurant(IFormFile file, Guid id, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.Include(x => x.RestaurantPhotos).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        var photoUploadResult = await _photoAccessor.AddPhoto(file);
        var photo = new PhotoForRestaurant
        {
            Url = photoUploadResult.Url,
            Id = photoUploadResult.PublicId
        };
        if (!restaurant.RestaurantPhotos.Any(x => x.IsMain)) photo.IsMain = true;

        restaurant.RestaurantPhotos.Add(photo);
        await _context.PhotosForRestaurant.AddAsync(photo, cancellationToken);
        _context.Restaurants.Update(restaurant);
    }

    public async Task<bool> DeletePhotoForRestaurant(string photoId, Guid id, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.Include(x => x.RestaurantPhotos).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);


        var photo = restaurant.RestaurantPhotos.FirstOrDefault(x => x.Id == photoId);


        if (photo.IsMain) return false;

        var result = await _photoAccessor.DeletePhoto(photo.Id);
        if (result == null) return false;

        restaurant.RestaurantPhotos.Remove(photo);
        _context.Remove(photo);
        return true;
    }

    public async Task<bool> SetMainPhotoForRestaurant(string photoId, Guid id, CancellationToken cancellationToken)
    {
        var restaurant = await _context.Restaurants.Include(x => x.RestaurantPhotos).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (restaurant == null) return false;

        var photo = restaurant.RestaurantPhotos.FirstOrDefault(x => x.Id == photoId);
        if (photo == null) return false;

        var currentMain = restaurant.RestaurantPhotos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;

        photo.IsMain = true;
        var modifiedPhoto = restaurant.RestaurantPhotos
            .Select(x =>
                x.Id == photo.Id
                    ? new PhotoForRestaurant
                        { Id = photo.Id, IsMain = true, Url = photo.Url, RestaurantsId = restaurant.Id }
                    : x)
            .ToList();
        restaurant.RestaurantPhotos = modifiedPhoto;
        _context.Restaurants.Update(restaurant);
        return true;
    }
}