using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.DTO;

public class UserDto
{
    public string Token { get; set; }
    public string Username { get; set; }
    public string Image { get; set; }
    public UserAddressesForCreation Address { get; set; }
}