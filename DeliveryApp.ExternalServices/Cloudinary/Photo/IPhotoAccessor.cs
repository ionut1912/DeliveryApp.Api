﻿using Microsoft.AspNetCore.Http;

namespace DeliveryApp.ExternalServices.Cloudinary.Photo;

public interface IPhotoAccessor
{
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<string> DeletePhoto(string publicId);
}