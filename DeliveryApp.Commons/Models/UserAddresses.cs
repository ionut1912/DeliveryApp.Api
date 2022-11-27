namespace DeliveryApp.Commons.Models;

public class UserAddresses
{
    public Guid addressId { get; set; }
    public int userId { get; set; }
    public string street { get; set; }
    public string number { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
}