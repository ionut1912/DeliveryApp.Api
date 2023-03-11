namespace DeliveryApp.Domain.DTO;

public class OrderForCreationDto
{
    public string RestaurantName { get; set; }
    public string ReceivedTime { get; set; }
    public List<string> MenuItemNames { get; set; }
}