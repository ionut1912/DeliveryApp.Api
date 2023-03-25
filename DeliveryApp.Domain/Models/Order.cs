using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public string ReceivedTime { get; set; }
    public double FinalPrice { get; set; }
    public string Status { get; set; }
    public UserDto User { get; set; }
    public RestaurantWithImage Restaurant { get; set; }
    public List<MenuItemWithImage> MenuItems { get; set; } = new();
}