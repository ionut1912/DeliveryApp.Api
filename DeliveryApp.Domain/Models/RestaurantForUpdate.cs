using DeliveryApp.Commons.Models;

namespace DeliveryApp.Domain.Models
{
    public class RestaurantForUpdate
    {
        public string name { get; set; }
        public RestaurantAddressesForUpdate address { get; set; }
    }
}
