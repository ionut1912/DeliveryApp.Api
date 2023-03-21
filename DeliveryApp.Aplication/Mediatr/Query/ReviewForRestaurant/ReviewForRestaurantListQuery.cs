using DeliveryApp.Commons.Query;

namespace DeliveryApp.Application.Mediatr.Query.ReviewForRestaurant;

public class ReviewForRestaurantListQuery : ListQuery<Domain.Models.ReviewForRestaurant>
{
    public Guid RestaurantId { get; set; }
}