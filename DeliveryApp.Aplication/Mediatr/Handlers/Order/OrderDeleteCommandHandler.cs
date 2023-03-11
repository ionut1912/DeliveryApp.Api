using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Commands;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Order;

public class OrderDeleteCommandHandler : ICommandHandler<DeleteCommand, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderDeleteCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Result> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.DeleteOrder(request.Id, cancellationToken);
        if (result is false) return Result.Failure(DomainMessages.Order.CanNotDeleteOrder(request.Id));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(DomainMessages.Order.OrderDeletedSuccessfully(request.Id));
    }
}