using DeliveryApp.Commons.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using Microsoft.AspNetCore.Identity;

namespace DeliveryApp.Repository.Entities;

public class Users : IdentityUser<int>
{
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public UserAddresses UserAddress { get; set; }
    public UserConfigs UserConfigs { get; set; }
}