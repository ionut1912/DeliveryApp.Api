using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class RestaurantWithImage
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public RestaurantAddresses Address { get; set; }
    public List<MenuItemWithImage> MenuItems { get; set; } = new();

    public List<ReviewForRestaurant> Reviews { get; set; } = new();
}