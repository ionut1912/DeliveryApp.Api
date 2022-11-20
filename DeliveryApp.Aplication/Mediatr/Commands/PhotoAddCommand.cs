using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Mediatr.Commands
{
    public class PhotoAddCommand : ICommand<Result<Photo>>

    {
        public IFormFile File { get; set; }
        public string email { get; set; }
    }
}
