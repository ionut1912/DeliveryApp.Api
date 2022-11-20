using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.Cloudinary.Photo;
using Microsoft.AspNetCore.Identity;

namespace DeliveryApp.Repository.Entities
{
    public class Users : IdentityUser<int>
    {
        public ICollection<Photo> photos { get; set; } = new List<Photo>();
        public UserAddresses userAddress { get; set; }
        public UserConfigs userConfigs { get; set; }
    }
}
