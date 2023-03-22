namespace DeliveryApp.Domain.DTO;

public class ReviewForMenuItemDto
{
    public string ReviewTitle { get; set; }
    public string ReviewDescription { get; set; }
    public int NumberOfStars { get; set; }
    public Guid MenuItemId { get; set; }
}