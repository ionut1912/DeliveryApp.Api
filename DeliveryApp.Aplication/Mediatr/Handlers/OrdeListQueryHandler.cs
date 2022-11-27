using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers;

public class OrdeListQueryHandler : IQueryHandler<
    ListQuery<Orders>,
    Result<List<Orders>>>
{
    private readonly IOrderRepository _orderRepository;

    public OrdeListQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<Result<List<Orders>>> Handle(
        ListQuery<Orders> request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrders(request, cancellationToken);
    }
}