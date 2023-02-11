using DeliveryApp.Aplication.Mediatr.Commands.Order;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Domain.Models;
using MediatR;

namespace DeliveryApp.Aplication.Repositories;

public interface IOrderRepository
{
    Task<Result<OrderForCreation>> AddOrder(OrderCreateCommand command, CancellationToken cancellationToken);

    Task<Result<List<OrderForCreation>>> GetOrders(ListQuery<OrderForCreation> command,
        CancellationToken cancellationToken);

    Task<Result<OrderForCreation>> GetOrder(QueryItem<OrderForCreation> query, CancellationToken cancellationToken);
    Task<Result<Unit>> EditOrder(OrderEditCommand command, CancellationToken cancellationToken);
    Task<Result<Unit>> DeleteOrder(DeleteCommand query, CancellationToken cancellationToken);
}