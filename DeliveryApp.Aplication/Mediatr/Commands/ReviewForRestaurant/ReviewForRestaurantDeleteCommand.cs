using DeliveryApp.Commons.Commands;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;

public class ReviewForRestaurantDeleteCommand : DeleteCommand
{
    public DeleteReviewForRestaurantRequest Request { get; set; }
}