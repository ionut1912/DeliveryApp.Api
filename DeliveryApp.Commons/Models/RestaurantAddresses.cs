namespace DeliveryApp.Commons.Models;

public class RestaurantAddresses
{
    public Guid AddressId { get; set; }
    public Guid RestaurantId { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}