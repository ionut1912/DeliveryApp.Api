using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Mediatr.Commands.Photo;

public class PhotoForMenuItemCreateCommand : ICommand<Result<PhotoForMenuItem>>
{
    public IFormFile File { get; set; }
    public Guid Id { get; set; }
}