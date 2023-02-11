using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoAddCommand : ICommand<Result<ExternalServices.Cloudinary.Photo.Photo>>

{
    public IFormFile File { get; set; }
}