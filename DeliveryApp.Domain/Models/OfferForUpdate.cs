namespace DeliveryApp.Domain.Models;

public class OfferForUpdate
{
    public string DateActiveFrom { get; set; }
    public string DateActiveTo { get; set; }
    public int Discount { get; set; }
    public Guid MenuItemId { get; set; }
}