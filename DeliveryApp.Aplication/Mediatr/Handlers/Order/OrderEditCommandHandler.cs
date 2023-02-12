﻿using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrderEditCommandHandler : ICommandHandler<OrderEditCommand, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderEditCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(OrderEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.EditOrder(request.Id, request.OrderForUpdate, cancellationToken);
        if (result is false) return Result.Failure($"Order with id {request.Id} can not be modified");

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success("Order modified successfully");
    }
}