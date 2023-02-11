using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoForMenuItemCreateCommand : ICommand<Result<PhotoForMenuItem>>
{
    public IFormFile File { get; set; }
    public Guid Id { get; set; }
}