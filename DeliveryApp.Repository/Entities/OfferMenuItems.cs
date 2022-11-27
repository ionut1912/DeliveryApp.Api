namespace DeliveryApp.Repository.Entities;

public class OfferMenuItems
{
    public Guid offerId { get; set; }
    public Offers offer { get; set; }
    public Guid menuItemId { get; set; }
    public MenuItems menuItem { get; set; }
}