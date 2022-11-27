using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.DTO;

public class UserDto
{
    public string token { get; set; }
    public string username { get; set; }
    public string? image { get; set; }
    public UserAddressesForCreation address { get; set; }
}