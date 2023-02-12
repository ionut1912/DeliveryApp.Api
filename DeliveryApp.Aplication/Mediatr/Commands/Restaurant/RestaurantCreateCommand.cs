using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantCreateCommand : ICommand<ResultT<Domain.Models.RestaurantDto>>
{
    public Domain.Models.RestaurantDto RestaurantForCreation { get; set; }
}