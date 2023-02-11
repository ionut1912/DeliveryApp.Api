using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrdeListQueryHandler : IQueryHandler<
    ListQuery<OrderForCreation>,
    Result<List<OrderForCreation>>>
{
    private readonly IOrderRepository _orderRepository;

    public OrdeListQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<Result<List<OrderForCreation>>> Handle(
        ListQuery<OrderForCreation> request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrders(request, cancellationToken);
    }
}