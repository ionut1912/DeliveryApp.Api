﻿using DeliveryApp.Application.Mediatr.Commands.Order;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Order;

public class OrderCreateCommandHandler : ICommandHandler<OrderCreateCommand, ResultT<JsonResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreateCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.AddOrder(request.Order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = DomainMessages.Order.OrderAddedSuccessfully
        };

        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}