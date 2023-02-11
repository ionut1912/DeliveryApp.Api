using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class Restaurant
{
    public string Name { get; set; }
    public RestaurantAddressesForCreation Address { get; set; }
}