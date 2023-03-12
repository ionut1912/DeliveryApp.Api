using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class Restaurant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public RestaurantAddresses Address { get; set; }
    public List<MenuItem> MenuItems { get; set; } = new();
}