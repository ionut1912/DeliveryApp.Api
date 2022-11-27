using MediatR;

namespace DeliveryApp.Commons.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}