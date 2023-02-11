using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.ExternalServices.Cloudinary
{
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
}
