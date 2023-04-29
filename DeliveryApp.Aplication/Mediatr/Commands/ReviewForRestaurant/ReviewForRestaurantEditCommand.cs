using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;

public class ReviewForRestaurantEditCommand : ICommand<ResultT<JsonResponse>>
{
    public Guid Id { get; set; }
    public EditReviewForRestaurantRequest Request { get; set; }
}