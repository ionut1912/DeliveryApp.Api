using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Commands.Order;

public class OrderCreateCommand : ICommand<Result<OrderForCreation>>
{
    public OrderForCreation Order { get; set; }
}