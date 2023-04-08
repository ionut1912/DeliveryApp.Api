namespace DeliveryApp.Domain.DTO;

public class OfferDtoForCreation
{
    public string DateActiveFrom { get; set; }
    public string DateActiveTo { get; set; }
    public int Discount { get; set; }
    public string MenuItemName { get; set; }
}