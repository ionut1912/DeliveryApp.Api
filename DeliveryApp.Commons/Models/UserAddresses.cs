namespace DeliveryApp.Commons.Models;

public class UserAddresses
{
    public Guid AddressId { get; set; }
    public int UserId { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}