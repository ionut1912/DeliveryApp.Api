using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Contracts
{
    public class EditUserAddressRequest
    {
        public string Language { get; set; }
        public UserAddressesForCreation UserAddressesForCreation { get; set; }
    }
}
