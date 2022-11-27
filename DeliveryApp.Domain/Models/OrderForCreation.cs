namespace DeliveryApp.Domain.Models;

public class OrderForCreation
{
    public string restaurantName { get; set; }
    public string receivedTime { get; set; }
    public string username { get; set; }
    public List<string> menuItemNames { get; set; }
}