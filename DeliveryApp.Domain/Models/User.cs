using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models;

public class User
{
    public List<string> Photos = new();
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public UserAddressesForCreation Address { get; set; }
    public UserConfig UserConfig { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public int OrdersCount { get; set; }
}