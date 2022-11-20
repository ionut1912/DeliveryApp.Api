using DeliveryApp.Commons.Models;

namespace DeliveryApp.Repository.Entities
{
    public class Restaurants
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public RestaurantAddresses address { get; set; }
    }
}
