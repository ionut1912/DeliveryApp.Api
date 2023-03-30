using DeliveryApp.Application.Mediatr.Query.Orders;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;

namespace DeliveryApp.Application.Mediatr.Handlers.Order;

public class CurrentUsersOrderQueryHandler : IQueryHandler<CurrentUserOrdersQuery, ResultT<List<Domain.Models.Order>>>
{
    private readonly IOrderRepository _orderRepository;

    public CurrentUsersOrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<ResultT<List<Domain.Models.Order>>> Handle(CurrentUserOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetCurrentUserOrders(cancellationToken);
        return ResultT<List<Domain.Models.Order>>.Success(order);
    }
}