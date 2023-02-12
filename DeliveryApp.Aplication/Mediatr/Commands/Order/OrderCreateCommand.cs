using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Aplication.Mediatr.Commands.Order;

public class OrderCreateCommand : ICommand<Result>
{
    public OrderForCreationDto Order { get; set; }
}