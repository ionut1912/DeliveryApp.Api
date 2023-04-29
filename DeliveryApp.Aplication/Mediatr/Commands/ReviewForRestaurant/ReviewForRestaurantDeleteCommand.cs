using DeliveryApp.Commons.Commands;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;

public class ReviewForRestaurantDeleteCommand : DeleteCommand
{
    public string Language { get; set; }
}