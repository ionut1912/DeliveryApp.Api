namespace DeliveryApp.Domain.DTO;

public class OfferDto
{
    public string DateActiveFrom { get; set; }
    public string DateActiveTo { get; set; }
    public int Discount { get; set; }
    public Guid MenuItemId { get; set; }
}