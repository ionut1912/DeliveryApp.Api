using DeliveryApp.Application.Repositories;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Repository.Services;

public class PhotoService : IPhotoRepository
{
    private readonly DeliveryContext _context;
    private readonly IPhotoAccessor _photoAccessor;
    private readonly IUserAccessor _userAccessor;

    public PhotoService(DeliveryContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _photoAccessor = photoAccessor ?? throw new ArgumentNullException(nameof(photoAccessor));
        _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
    }

    public async Task AddPhoto(IFormFile file, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(p => p.Photos)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);

        var photoUploadResult = await _photoAccessor.AddPhoto(file);
        var photo = new Photo
        {
            Url = photoUploadResult.Url,
            Id = photoUploadResult.PublicId
        };
        if (!user.Photos.Any(x => x.IsMain)) photo.IsMain = true;

        user.Photos.Add(photo);
        await _context.PhotosForUser.AddAsync(photo, cancellationToken);
        _context.Users.Update(user);
    }

    public async Task<bool> DeletePhoto(string id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(p => p.Photos)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);

        var photo = user.Photos.FirstOrDefault(x => x.Id == id);
        if (photo == null) return false;

        if (photo.IsMain) return false;

        var result = await _photoAccessor.DeletePhoto(photo.Id);

        user.Photos.Remove(photo);
        _context.Users.Remove(user);
        return true;
    }

    public async Task<bool> SetMainPhoto(string id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(p => p.Photos)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername(), cancellationToken);


        var photo = user.Photos.FirstOrDefault(x => x.Id == id);
        if (photo == null) return false;

        var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;

        photo.IsMain = true;
        var modifiedPhoto = user.Photos
            .Select(x => x.Id == photo.Id ? new Photo { Id = photo.Id, IsMain = true, Url = photo.Url } : x)
            .ToList();
        user.Photos = modifiedPhoto;
        _context.Users.Update(user);
        return true;
    }
}