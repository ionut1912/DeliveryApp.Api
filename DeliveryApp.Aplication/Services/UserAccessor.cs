using DeliveryApp.Aplication.Repositories;
using System.Security.Claims;

namespace DeliveryApp.Aplication.Services
{
    public class UserAccessor:IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
        }
        public string GetUsername()
        {
            return _httpContextAccesor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}
