using DeliveryApp.Aplication.Mediatr.Commands;
using DeliveryApp.Aplication.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Repository.Entities;

namespace DeliveryApp.Aplication.Mediatr.Handlers
{
    public class OrderCreateCommandHandler : ICommandHandler<OrderCreateCommand, Result<Orders>>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCreateCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<Result<Orders>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.AddOrder(request, cancellationToken);
        }
    }
}
