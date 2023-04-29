using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;

namespace DeliveryApp.Application.Mediatr.Commands.Order;

public class OrderCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public CreateOrderRequest Request { get; set; }
}