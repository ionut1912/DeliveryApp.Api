
using DeliveryApp.Commons.Models;
using DeliveryApp.ExternalServices.Cloudinary.Photo;

namespace DeliveryApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Email { get; set; }
        public UserAddressesForCreation Address { get; set; }
        public  UserConfig UserConfig { get; set; }
        public  string PhoneNumber { get; set; }
        public List<string> Photos=new();
        public string Role { get; set; }
    }
}
