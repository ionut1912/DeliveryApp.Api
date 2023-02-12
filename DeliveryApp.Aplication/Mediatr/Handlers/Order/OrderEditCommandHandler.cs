﻿using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrderEditCommandHandler : ICommandHandler<OrderEditCommand, ResultT<Unit>>
{
    private readonly IOrderRepository _orderRepository;

    public OrderEditCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<ResultT<Unit>> Handle(OrderEditCommand request, CancellationToken cancellationToken)
    {
        return await _orderRepository.EditOrder(request, cancellationToken);
    }
}