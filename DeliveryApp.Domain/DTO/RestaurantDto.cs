using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.DTO;

public class RestaurantDto
{
    public string Name { get; set; }
    public RestaurantAddressesForCreation Address { get; set; }
}