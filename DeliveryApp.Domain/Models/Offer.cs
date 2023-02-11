namespace DeliveryApp.Domain.Models;

public class Offer
{
    public string DateActiveFrom { get; set; }
    public string DateActiveTo { get; set; }
    public int Discount { get; set; }
    public Guid MenuItemId { get; set; }
}