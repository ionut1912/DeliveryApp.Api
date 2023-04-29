using System.ComponentModel.DataAnnotations;
using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.DTO;

public class RegisterDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }

    [Required] public string Username { get; set; }

    [Required] public string PhoneNumber { get; set; }

    [Required] public UserAddressesForCreation AddressForCreation { get; set; }
    public string Language { get; set; }
}