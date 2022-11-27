using System.ComponentModel.DataAnnotations;
using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.DTO;

public class RegisterDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Password { get; set; }

    [Required] public string Username { get; set; }

    public UserAddressesForCreation addressForCreation { get; set; }
}