using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Models;

public class Order
{
    public Guid Id { get; set; }
    public string ReceivedTime { get; set; }
    public double FinalPrice { get; set; }
    public string Status { get; set; }
    public UserDto User { get; set; }
    public List<Restaurant> Restaurants { get; set; }
    public List<MenuItem> MenuItems { get; set; } = new();
}