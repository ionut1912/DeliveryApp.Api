using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class RestaurantForCreation
{
    public string name { get; set; }
    public RestaurantAddressesForCreation address { get; set; }
}