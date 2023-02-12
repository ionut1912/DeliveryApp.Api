namespace DeliveryApp.Domain.DTO;

public class OrderForCreationDto
{
    public string RestaurantName { get; set; }
    public string ReceivedTime { get; set; }
    public string Username { get; set; }
    public RestaurantDto Restaurant { get; set; }
    public List<string> MenuItemNames { get; set; }
}