using DeliveryApp.Domain.Cloudinary.Photo;

namespace DeliveryApp.Aplication.Repositories
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}
