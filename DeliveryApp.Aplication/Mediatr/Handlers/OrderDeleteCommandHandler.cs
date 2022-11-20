using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class OrderDeleteCommandHandler : ICommandHandler<DeleteCommand, Result<Unit>>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDeleteCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<Result<Unit>> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.DeleteOrder(request, cancellationToken);
        }
    }
}
