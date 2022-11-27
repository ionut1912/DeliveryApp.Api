using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Mediatr.Commands;

public class PhotoForMenuItemCreateCommand : ICommand<Result<PhotoForMenuItem>>
{
    public IFormFile file { get; set; }
    public Guid id { get; set; }
}