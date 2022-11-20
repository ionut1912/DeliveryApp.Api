using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Query;
using DeliveryApp.Repository.Entities;
using MediatR;

namespace DeliveryApp.Aplication.Repositories
{

    public interface IOrderRepository
    {
        Task<Result<Orders>> AddOrder(OrderCreateCommand command, CancellationToken cancellationToken);
        Task<Result<List<Orders>>> GetOrders(ListQuery<Orders> command, CancellationToken cancellationToken);
        Task<Result<Orders>> GetOrder(QueryItem<Orders> query, CancellationToken cancellationToken);
        Task<Result<Unit>> EditOrder(OrderEditCommand command, CancellationToken cancellationToken);
        Task<Result<Unit>> DeleteOrder(DeleteCommand query, CancellationToken cancellationToken);
    }
}
