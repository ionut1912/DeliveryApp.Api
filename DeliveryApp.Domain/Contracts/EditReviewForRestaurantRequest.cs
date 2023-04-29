using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class EditReviewForRestaurantRequest
{
    public string Language { get; set; }
    public ReviewForRestaurantDto ReviewForRestaurantDto { get; set; }
}