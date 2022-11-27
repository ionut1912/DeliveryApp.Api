using MediatR;

namespace DeliveryApp.Commons.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}