namespace DeliveryApp.Repository.Entities;

public class OfferMenuItems
{
    public Guid OfferId { get; set; }
    public Offers Offer { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItems MenuItem { get; set; }
}