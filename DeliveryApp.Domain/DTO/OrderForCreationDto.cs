using DeliveryApp.Domain.Models;

namespace DeliveryApp.Domain.DTO;

public class OrderForCreationDto
{
    public List<string> RestaurantNames { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}