using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrderCreateCommandHandler : ICommandHandler<OrderCreateCommand, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCreateCommandHandler(IOrderRepository _orderRepository,IUnitOfWork _unitOfWork)
    {
        
    }

    public async Task<Result> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        
    }
}