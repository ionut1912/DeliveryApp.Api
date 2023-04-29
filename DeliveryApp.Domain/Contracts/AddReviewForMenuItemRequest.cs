using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class AddReviewForMenuItemRequest
{
    public string Language { get; set; }
    public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
}