using DeliveryApp.Aplication.Mediatr.Commands.Photo;
using DeliveryApp.Commons.Core;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Aplication.Repositories;

public interface IPhotoRepository
{
    Task AddPhoto(IFormFile file, CancellationToken cancellationToken);
    Task<bool> DeletePhoto(string id, CancellationToken cancellationToken);
    Task<bool> SetMainPhoto(string id, CancellationToken cancellationToken);
}