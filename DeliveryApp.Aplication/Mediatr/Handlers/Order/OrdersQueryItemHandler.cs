using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Order;

public class OrdersQueryItemHandler : IQueryHandler<
    QueryItem<Domain.Models.Order>,
    ResultT<Domain.Models.Order>>
{
    private readonly IOrderRepository _orderRepository;

    public OrdersQueryItemHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }


    public async Task<ResultT<Domain.Models.Order>> Handle(QueryItem<Domain.Models.Order> request,
        CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetOrder(request.Id, cancellationToken);
        if (result is null) return ResultT<Domain.Models.Order>.Failure(DomainMessages.Order.OrderNotFound(request.Id));
        return ResultT<Domain.Models.Order>.Success(result);
    }
}