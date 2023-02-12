using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.DTO;
using DeliveryApp.Domain.Models;

namespace DeliveryApp.Aplication.Mediatr.Handlers.Order;

public class OrdeListQueryHandler : IQueryHandler<
    ListQuery<Domain.Models.Order>,
    ResultT<List<Domain.Models.Order>>>
{
    private readonly IOrderRepository _orderRepository;

    public OrdeListQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<ResultT<List<Domain.Models.Order>>> Handle(
        ListQuery<Domain.Models.Order> request,
        CancellationToken cancellationToken)
    {
        var result= await _orderRepository.GetOrders(cancellationToken);
        return  ResultT<List<Domain.Models.Order>>.Success(result);
    }
}