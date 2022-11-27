namespace DeliveryApp.Domain.Models;

public class OfferForUpdate
{
    public string dateActiveFrom { get; set; }
    public string dateActiveTo { get; set; }
    public int discount { get; set; }
    public Guid menuItemId { get; set; }
}