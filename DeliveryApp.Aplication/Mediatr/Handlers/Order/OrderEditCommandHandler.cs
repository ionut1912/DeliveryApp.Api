using DeliveryApp.Application.Mediatr.Commands.Order;
using DeliveryApp.Application.Repositories;
using DeliveryApp.Commons.Core;
using DeliveryApp.Commons.Interfaces;
using DeliveryApp.Domain.Messages;

namespace DeliveryApp.Application.Mediatr.Handlers.Order;

public class OrderEditCommandHandler : ICommandHandler<OrderEditCommand, ResultT<JsonResponse>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderEditCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ResultT<JsonResponse>> Handle(OrderEditCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.EditOrder(request.Id, request.Request.OrderForUpdate, cancellationToken);
        if (result is false)
        {
            var jsonResponseFailure = new JsonResponse
            {
                Message = request.Request.Language == "EN"
                    ? DomainMessagesEn.Order.CanNotEditOrder(request.Id)
                    : DomainMessagesRo.Order.CanNotEditOrder(request.Id)
            };
            return ResultT<JsonResponse>.Failure(jsonResponseFailure.Message);
        }


        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var jsonResponseSuccess = new JsonResponse
        {
            Message = request.Request.Language == "EN"
                ? DomainMessagesEn.Order.OrderEditedSuccessfully(request.Id)
                : DomainMessagesRo.Order.OrderEditedSuccessfully(request.Id)
        };
        return ResultT<JsonResponse>.Success(jsonResponseSuccess);
    }
}