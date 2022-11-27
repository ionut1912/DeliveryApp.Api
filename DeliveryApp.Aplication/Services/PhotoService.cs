using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Domain.Cloudinary.Photo;
using DeliveryApp.Repository.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApp.Aplication.Services;

public class PhotoService : IPhotoRepository
{
    private readonly DeliveryContext _context;
    private readonly IPhotoAccessor _photoAccessor;
    private  readonly  IUserAccessor _userAccessor;

    public PhotoService(DeliveryContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _photoAccessor = photoAccessor ?? throw new ArgumentNullException(nameof(photoAccessor));
        _userAccessor = userAccessor ?? throw  new ArgumentNullException(nameof(userAccessor));
    }

    public async Task<Result<Photo>> AddPhoto(PhotoAddCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(p => p.photos)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
        if (user == null)
        {
            return null;
        }
        var photoUploadResult = await _photoAccessor.AddPhoto(command.File);
        var photo = new Photo
        {
            Url = photoUploadResult.Url,
            Id = photoUploadResult.PublicId
        };
        if (!user.photos.Any(x => x.IsMain))
        {
            photo.IsMain = true;
        }
        user.photos.Add(photo);
        var result = await _context.SaveChangesAsync() > 0;
        if (result) return Result<Photo>.Success(photo);
        return Result<Photo>.Failure("Problems adding the photo");
    }

    public async Task<Result<Unit>> DeletePhoto(PhotoDeleteCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(p => p.photos)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
        if (user == null)
        {
            return null;
        }
        var photo = user.photos.FirstOrDefault(x => x.Id == command.Id);
        if (photo == null)
        {
            return null;
        }
        if (photo.IsMain)
        {
            return Result<Unit>.Failure("You can't delete your main photo");
        }
        var result = await _photoAccessor.DeletePhoto(photo.Id);
        if (result == null)
        {
            return Result<Unit>.Failure("Problem deleting photo from Cloudinary");
        }
        user.photos.Remove(photo);
        var succes = await _context.SaveChangesAsync() > 0;
        if (succes)
        {
            return Result<Unit>.Success(Unit.Value);
        }
        return Result<Unit>.Failure("Problem deleting photo from API");
    }

    public async Task<Result<Unit>> SetMainPhoto(PhotoSetMainCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(p => p.photos)
            .FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
        if (user == null)
        {
            return null;
        }
        var photo = user.photos.FirstOrDefault(x => x.Id == command.Id);
        if (photo == null)
        {
            return null;
        }
        var currentMain = user.photos.FirstOrDefault(x => x.IsMain);
        if (currentMain != null)
        {
            currentMain.IsMain = false;
        }
        photo.IsMain = true;
        var succes = await _context.SaveChangesAsync() > 0;
        if (succes)
        {
            return Result<Unit>.Success(Unit.Value);
        }
        return Result<Unit>.Failure("Problem setting main photo");
    }
}