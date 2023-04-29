using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Domain.Contracts;

public class AddReviewForRestaurantRequest
{
    public string Language { get; set; }
    public ReviewForRestaurantDto ReviewForRestaurantDto { get; set; }
}