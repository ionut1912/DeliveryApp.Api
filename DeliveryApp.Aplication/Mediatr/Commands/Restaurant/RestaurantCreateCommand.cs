using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Commands.Restaurant;

public class RestaurantCreateCommand : ICommand<Result<Domain.Models.Restaurant>>
{
    public Domain.Models.Restaurant RestaurantForCreation { get; set; }
}