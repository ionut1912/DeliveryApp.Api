namespace DeliveryApp.Domain.Models;

public class OrderForCreation
{
    public string RestaurantName { get; set; }
    public string ReceivedTime { get; set; }
    public string Username { get; set; }
    public List<string> MenuItemNames { get; set; }
}