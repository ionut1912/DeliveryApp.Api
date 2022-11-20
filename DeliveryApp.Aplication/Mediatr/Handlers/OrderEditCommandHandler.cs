using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using MediatR;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class OrderEditCommandHandler : ICommandHandler<OrderEditCommand, Result<Unit>>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderEditCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<Result<Unit>> Handle(OrderEditCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.EditOrder(request, cancellationToken);
        }
    }
}
