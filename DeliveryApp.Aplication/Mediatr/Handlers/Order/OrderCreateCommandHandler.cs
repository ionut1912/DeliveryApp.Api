using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrderCreateCommandHandler : ICommandHandler<OrderCreateCommand, Result<OrderForCreation>>
{
    private readonly IOrderRepository _orderRepository;

    public OrderCreateCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<Result<OrderForCreation>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.AddOrder(request, cancellationToken);
    }
}