using DeliveryApp.Commons.Models;

namespace DeliveryApp.Repository.Entities;

public class Restaurant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RestaurantAddresses Address { get; set; }
}