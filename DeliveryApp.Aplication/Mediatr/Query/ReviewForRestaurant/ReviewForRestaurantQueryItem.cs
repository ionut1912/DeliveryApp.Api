using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;

public class ReviewForRestaurantQueryItem : QueryItem<Domain.Models.ReviewForRestaurant>
{
    public Guid RestaurantId { get; set; }
}