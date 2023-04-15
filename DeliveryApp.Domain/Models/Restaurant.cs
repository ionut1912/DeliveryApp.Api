using DeliveryApp.Commons.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.Domain.Models;

public class Restaurant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MenuItem> MenuItems { get; set; } = new();
    public RestaurantAddresses Address { get; set; }
    public ICollection<PhotoForRestaurant> RestaurantPhotos { get; set; } = new List<PhotoForRestaurant>();
    public ICollection<MenuItemRestaurant> MenuItemsRestaurants { get; set; } = new List<MenuItemRestaurant>();
    public List<Order> Orders { get; set; } = new();
    public List<ReviewForRestaurant> Reviews { get; set; } = new();
}