using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;

public class ReviewForRestaurantCreateCommand : ICommand<Result>
{
    public ReviewForRestaurantDto ReviewForRestaurantDto { get; set; }
}