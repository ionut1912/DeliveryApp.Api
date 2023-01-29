using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class RestaurantForUpdate
{
    public string Name { get; set; }
    public RestaurantAddressesForUpdate Address { get; set; }
}