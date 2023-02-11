using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.ExternalServices.Cloudinary;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using MediatR;
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

    public async Task<Result<PhotoForMenuItem>> AddPhotoForMenuItem(PhotoForMenuItemCreateCommand command,
        CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        if (menuItem == null) return null;

        var photoUploadResult = await _photoAccessor.AddPhoto(command.File);
        var photo = new PhotoForMenuItem
        {
            Url = photoUploadResult.Url,
            Id = photoUploadResult.PublicId
        };
        if (!menuItem.Photos.Any(x => x.IsMain)) photo.IsMain = true;

        menuItem.Photos.Add(photo);
        _context.PhotosForMenuItem.Add(photo);
        _context.MenuItems.Update(menuItem);
        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        return result
            ? Result<PhotoForMenuItem>.Success(photo)
            : Result<PhotoForMenuItem>.Failure("Problems adding the photo");
    }

    public async Task<Result<Unit>> DeletePhotoForMenuItem(PhotoForMenuItemDeleteCommand command,
        CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == command.ItemId, cancellationToken);
        if (menuItem == null) return null;

        var photo = menuItem.Photos.FirstOrDefault(x => x.Id == command.PhotoId);
        if (photo == null) return null;

        if (photo.IsMain) return Result<Unit>.Failure("You can't delete your main photo");

        var result = await _photoAccessor.DeletePhoto(photo.Id);
        if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");

        menuItem.Photos.Remove(photo);
        _context.Remove(photo);
        var success = await _context.SaveChangesAsync() > 0;
        return success ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem deleting photo from API");
    }

    public async Task<Result<Unit>> SetMainPhotoForMenuItem(PhotoForMenuItemSetMainCommand command,
        CancellationToken cancellationToken)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == command.ItemId, cancellationToken);
        if (menuItem == null) return null;

        var photo = menuItem.Photos.FirstOrDefault(x => x.Id == command.PhotoId);
        if (photo == null) return null;

        var currentMain = menuItem.Photos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;

        photo.IsMain = true;
        _context.PhotosForMenuItem.Update(photo);
        var success = await _context.SaveChangesAsync() > 0;
        return success ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Problem setting main photo");
    }
}