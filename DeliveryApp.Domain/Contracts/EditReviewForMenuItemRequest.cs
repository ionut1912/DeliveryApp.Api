using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class EditReviewForMenuItemRequest
{
    public string Language { get; set; }
    public ReviewForMenuItemDto ReviewForMenuItemDto { get; set; }
}