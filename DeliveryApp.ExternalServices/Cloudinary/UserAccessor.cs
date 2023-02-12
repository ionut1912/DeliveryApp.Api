using System.Security.Claims;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.ExternalServices.Cloudinary;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccesor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccesor = httpContextAccessor;
    }

    public string GetUsername()
    {
        return _httpContextAccesor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
    }
}