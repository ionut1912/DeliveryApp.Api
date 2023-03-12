using DeliveryApp.Application.Repositories;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class PhotoForMenuItemService : IPhotoForMenuItemRepository
{
    private readonly DeliveryContext _context;
    private readonly IPhotoAccessor _photoAccessor;

    public PhotoForMenuItemService(DeliveryContext context, IPhotoAccessor photoAccessor)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _photoAccessor = photoAccessor ?? throw new ArgumentNullException(nameof(photoAccessor));
    }

    public async Task AddPhotoForMenuItem(IFormFile file, Guid id, CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.Include(x => x.Photos).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        var photoUploadResult = await _photoAccessor.AddPhoto(file);
        var photo = new PhotoForMenuItem
        {
            Url = photoUploadResult.Url,
            Id = photoUploadResult.PublicId
        };
        if (!menuItem.Photos.Any(x => x.IsMain)) photo.IsMain = true;

        menuItem.Photos.Add(photo);
        await _context.PhotosForMenuItem.AddAsync(photo, cancellationToken);
        _context.MenuItems.Update(menuItem);
    }

    public async Task<bool> DeletePhotoForMenuItem(string photoId, Guid id, CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems
            .Include(x => x.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);


        var photo = menuItem.Photos.FirstOrDefault(x => x.Id == photoId);


        if (photo.IsMain) return false;

        var result = await _photoAccessor.DeletePhoto(photo.Id);
        if (result == null) return false;

        menuItem.Photos.Remove(photo);
        _context.Remove(photo);
        return true;
    }

    public async Task<bool> SetMainPhotoForMenuItem(string photoId, Guid id, CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems
            .Include(x => x.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        var photo = menuItem?.Photos.FirstOrDefault(x => x.Id == photoId);
        if (photo == null) return false;

        var currentMain = menuItem.Photos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;

        photo.IsMain = true;
        var modifiedPhoto = menuItem.Photos
            .Select(x =>
                x.Id == photo.Id
                    ? new PhotoForMenuItem { Id = photo.Id, IsMain = true, Url = photo.Url, MenuItemId = menuItem.Id }
                    : x)
            .ToList();
        menuItem.Photos = modifiedPhoto;
        _context.MenuItems.Update(menuItem);
        return true;
    }
}