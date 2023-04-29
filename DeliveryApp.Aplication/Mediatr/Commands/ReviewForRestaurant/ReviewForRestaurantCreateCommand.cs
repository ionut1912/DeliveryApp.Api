using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;

public class ReviewForRestaurantCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public AddReviewForRestaurantRequest Request { get; set; }
}