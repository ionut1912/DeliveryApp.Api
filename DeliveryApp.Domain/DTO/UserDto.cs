using DeliveryApp.Commons.Models;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Domain.DTO;

public class UserDto
{
    public string PhoneNumber { get; set; }
    public string Token { get; set; }
    public string Username { get; set; }
    public string Image { get; set; }
    public string Email { get; set; }
    public UserConfig UserConfig { get; set; }
    public UserAddressesForCreation Address { get; set; }
}