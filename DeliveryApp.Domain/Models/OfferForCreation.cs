namespace DeliveryApp.Domain.Models;

public class OfferForCreation
{
    public string dateActiveFrom { get; set; }
    public string dateActiveTo { get; set; }
    public int discount { get; set; }
    public Guid menuItemId { get; set; }
}