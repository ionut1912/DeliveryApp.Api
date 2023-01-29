using DeliveryApp.Commons.Models;

namespace DeliveryApp.Repository.Entities;

public class Restaurants
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RestaurantAddresses Address { get; set; }
}