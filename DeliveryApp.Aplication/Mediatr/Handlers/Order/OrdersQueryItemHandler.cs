using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrdersQueryItemHandler : IQueryHandler<
    QueryItem<OrderForCreationDto>,
    ResultT<OrderForCreationDto>>
{
    private readonly IOrderRepository _orderRepository;

    public OrdersQueryItemHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<ResultT<OrderForCreationDto>> Handle(
        QueryItem<OrderForCreationDto> request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrder(request, cancellationToken);
    }
}