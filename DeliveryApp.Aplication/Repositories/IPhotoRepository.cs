using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Core;
using DeliveryApp.Domain.Cloudinary.Photo;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IPhotoRepository
{
    Task<Result<Photo>> AddPhoto(PhotoAddCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> DeletePhoto(PhotoDeleteCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> SetMainPhoto(PhotoSetMainCommand command, CancellationToken cancellationToken);
}