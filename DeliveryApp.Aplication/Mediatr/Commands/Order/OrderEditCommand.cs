using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Contracts;
using DeliveryApp.Domain.DTO;

namespace DeliveryApp.Application.Mediatr.Commands.Order;

public class OrderEditCommand : ICommand<ResultT<JsonResponse>>
{

    public Guid Id { get; set; }
    public  EditOrderRequest Request { get; set; }
  
}