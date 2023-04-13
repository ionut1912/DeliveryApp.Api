using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Order;

public class OrderCreateCommand : ICommand<ResultT<JsonResponse>>
{
    public OrderForCreationDto Order { get; set; }
}