using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoAddCommand : ICommand<Result<Domain.Cloudinary.Photo.Photo>>

{
    public IFormFile File { get; set; }
}