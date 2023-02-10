using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrdersQueryItemHandler : IQueryHandler<
    QueryItem<Orders>,
    Result<Orders>>
{
    private readonly IOrderRepository _orderRepository;

    public OrdersQueryItemHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<Result<Orders>> Handle(
        QueryItem<Orders> request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrder(request, cancellationToken);
    }
}