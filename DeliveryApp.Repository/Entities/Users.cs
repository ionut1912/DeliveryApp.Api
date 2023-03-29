using DeliveryApp.Commons.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;
using Microsoft.AspNetCore.Identity;

namespace DeliveryApp.Repository.Entities;

public class Users : IdentityUser<int>
{
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();
    public ICollection<ReviewForMenuItems> ReviewsForMenuItems { get; set; } = new List<ReviewForMenuItems>();
    public ICollection<ReviewForRestaurants> ReviewForRestaurants { get; set; } = new List<ReviewForRestaurants>();
    public List<Orders> Orders { get; set; } = new();
    public UserAddresses UserAddress { get; set; }
    public UserConfigs UserConfigs { get; set; }
}