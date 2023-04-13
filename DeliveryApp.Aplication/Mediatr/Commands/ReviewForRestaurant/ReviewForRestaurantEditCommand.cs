using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.ReviewForRestaurant;

public class ReviewForRestaurantEditCommand : ICommand<ResultT<JsonResponse>>
{
    public Guid Id { get; set; }
    public ReviewForRestaurantDto ReviewForRestaurant { get; set; }
}