using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.DTO;

public class RestaurantForUpdateDto
{
    public string Name { get; set; }
    public RestaurantAddressesForUpdate Address { get; set; }
}